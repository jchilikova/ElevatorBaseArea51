using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainApp.Models;

namespace MainApp
{
    class MainApp
    {
        static void Main(string[] args)
        {

            var buttonGfloor = new Button(Floors.G);
            var buttonSfloor = new Button(Floors.S);
            var buttonT1floor = new Button(Floors.T1);
            var buttonT2floor = new Button(Floors.T2);

            var buttonArray = new Button[]
            {
                buttonGfloor,
                buttonSfloor,
                buttonT1floor,
                buttonT2floor
            };

            var elevatorDoor = new SecurityChecker();
            var baseElevator = new Elevator(Floors.G , Floors.G,buttonArray, elevatorDoor);
            var agentMulder = new Agent("Agent Mulder", ClearenceTypes.TopSecret, Floors.T1, 1000, baseElevator);
            var agentShelby = new Agent("Agent Shelby", ClearenceTypes.TopSecret, Floors.T2, 500, baseElevator);
            var agentJohnson = new Agent("Agent Johnson", ClearenceTypes.Secret, Floors.G, 500, baseElevator);
            var agentJohny = new Agent("Agent Johny", ClearenceTypes.Confidential, Floors.G, 500, baseElevator);
            var agentAmanda = new Agent("Agent Amanda", ClearenceTypes.Secret, Floors.S, 854, baseElevator);
            var agentGretchen = new Agent("Agent Gretchen ", ClearenceTypes.Confidential, Floors.G, 500, baseElevator);



            var elevatorThread = new Thread(baseElevator.MoveElevator);
            var agentMulderThread = new Thread(agentMulder.MoveAround);
            var agentShelbyThread = new Thread(agentShelby.MoveAround);
            var agentJohnsonThread = new Thread(agentJohnson.MoveAround);
            var agentJohnyThread = new Thread(agentJohny.MoveAround);
            var agentAmandaThread = new Thread(agentAmanda.MoveAround);
            var agentGretchenThread = new Thread(agentGretchen.MoveAround);

            

            elevatorThread.Start();
            agentMulderThread.Start();
            agentShelbyThread.Start();
            agentJohnsonThread.Start();
            agentJohnyThread.Start();
            agentAmandaThread.Start();
            agentGretchenThread.Start();
       

            var agentList = new List<Agent>();
            agentList.Add(agentMulder);
            agentList.Add(agentShelby);
            agentList.Add(agentJohnson);
            agentList.Add(agentJohny);
            agentList.Add(agentAmanda);
            agentList.Add(agentGretchen);
      

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Activity Log {0}:", i+1);
                Console.WriteLine("Elevator is at floor {0}, target floor is {1}", baseElevator.CurrentFloor, baseElevator.DestinationFloor);
                foreach (var agent in agentList)
                {
                    Console.WriteLine("{0} is on floor {1}, doing : {2}",
                        agent.Name, agent.CurrentFloor.ToString(),agent.CurrentActivity);
                    
                }

                Console.WriteLine();

                Thread.Sleep(1000);
            }

            agentMulderThread.Abort();
            agentShelbyThread.Abort();
            agentJohnsonThread.Abort();
            agentJohnyThread.Abort();
            agentAmandaThread.Abort();
            agentGretchenThread.Abort();
           
            elevatorThread.Abort();

            Console.WriteLine("This is the end..");
            Console.ReadLine();
        }
    }
}
