using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    public class Button
    {
        public Floors TargetFloor { get; private set; }
        public Button(Floors targetFloor)
        {
            this.TargetFloor = targetFloor;
        }

        public Floors PressButton()
        {
            return this.TargetFloor;
        }
    }
}
