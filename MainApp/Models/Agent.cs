using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainApp.Interfaces;

namespace MainApp.Models
{
    public class Agent: IAgent
    {
        public string Name { get; }
        public ClearenceTypes Clearence { get; }
        public Floors CurrentFloor { get; set; }
        public int BusyTime { get; }
        public string CurrentActivity { get; private set; }

        private readonly Random activityGen  = new Random();
        private readonly Elevator elevator;

        public Agent(string name, ClearenceTypes clearence, Floors startingLocation, int busyTime, Elevator elevator)
        {
            this.Name = name;
            this.Clearence = clearence;
            this.CurrentFloor = startingLocation;
            this.BusyTime = busyTime;
            this.CurrentActivity = Constants.defaultActivity;
            this.elevator = elevator;
        }

        public void MoveAround()
        {
            while (true)
            {
                int randomActivity = activityGen.Next(0, Constants.Activities.Length-1);
                this.CurrentActivity = Constants.Activities[randomActivity];
                if (CurrentActivity == "Waiting for the elevator.")
                {
                    elevator.ElevatorSemaphore.WaitOne();
                    elevator.CallElevator(this.CurrentFloor);
                    while (elevator.IsMoving)
                    {
                        //wait here
                    }

                    this.CurrentActivity = Constants.elevatorActivity;
                    var doorOpened = false;
                    while (doorOpened == false)
                    {
                        elevator.PressButton();
                        while (elevator.IsMoving)
                        {
                            //wait for the elevator to arrive at the target floor
                        }

                        doorOpened =
                            elevator.ElevatorDoor.CheckSecurityClearence(elevator.CurrentFloor, this.Clearence);
                        if (doorOpened == false)
                        {
                            Console.WriteLine("Door failed to open for {0} at floor {1}.", this.Name, this.elevator.CurrentFloor);
                            Console.WriteLine();
                        }
                    }

                    this.CurrentFloor = this.elevator.CurrentFloor;
                    elevator.ElevatorSemaphore.Release();
                    this.CurrentActivity = Constants.exitingElevatorActivity;
                    Console.WriteLine("Door opened for {0} at floor {1}.", this.Name, this.elevator.CurrentFloor);
                    Console.WriteLine();
                }

                Thread.Sleep(BusyTime);
            }

        }
    }
}
