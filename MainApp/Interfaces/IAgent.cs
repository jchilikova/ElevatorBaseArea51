using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Interfaces
{
    public interface IAgent
    {
        string Name { get; }
        ClearenceTypes Clearence { get; }

        Floors CurrentFloor { get; set; }
        
        int BusyTime { get; }

        string CurrentActivity { get; }

        void MoveAround();
    }
}
