using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.Models;

namespace MainApp.Interfaces
{
    public interface IElevator
    {
        Floors DestinationFloor { get; }
        Floors CurrentFloor { get; }
        Button[] Buttons { get; }
        SecurityChecker ElevatorDoor { get; }
        bool IsMoving { get; }
        void PressButton();
        void MoveElevator();
        void CallElevator(Floors target);

    }
}
