using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainApp.Interfaces;

namespace MainApp.Models
{
    public class Elevator: IElevator
    {
        public Floors DestinationFloor { get; private set; }
        public Floors CurrentFloor { get; private set; }
        public Button[] Buttons { get; }
        public SecurityChecker ElevatorDoor { get; }
        public bool IsMoving { get; private set; }

        private readonly Random buttonGen = new Random();

        public Semaphore ElevatorSemaphore = new Semaphore(1,1);

        public Elevator(Floors destinationFloor, Floors currentFloor, Button[] buttons, SecurityChecker elevatorDoor)
        {
            DestinationFloor = destinationFloor;
            CurrentFloor = currentFloor;
            Buttons = buttons;
            ElevatorDoor = elevatorDoor;
            this.IsMoving = false;
        }
        public void PressButton()
        {
            this.IsMoving = true;
            var pressedDifferntFloor = false;
            while (pressedDifferntFloor == false)
            {
                var randButton = buttonGen.Next(0, this.Buttons.Length-1);
                var pressedButton = Buttons[randButton];
                this.DestinationFloor = pressedButton.PressButton();
                if (this.DestinationFloor != this.CurrentFloor)
                {
                    pressedDifferntFloor = true;
                }
            }
        }

        public void CallElevator(Floors target)
        {
            this.IsMoving = true;
            this.DestinationFloor = target;
        }

        public void MoveElevator()
        {
            while (true)
            {
                int currFloorNum = (int)this.CurrentFloor;
                int destFloorNum = (int)this.DestinationFloor;

                if (currFloorNum != destFloorNum)
                {
                    this.IsMoving = true;
                    if (currFloorNum < destFloorNum)
                    {
                        currFloorNum++;
                    }
                    else
                    {
                        currFloorNum--;
                    }
                }
                else
                {
                    this.IsMoving = false;
                }

                this.CurrentFloor = (Floors)currFloorNum;

                Thread.Sleep(1000);
            }
            
        }
    }
}
