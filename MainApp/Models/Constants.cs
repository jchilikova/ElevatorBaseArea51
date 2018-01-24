using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    public class Constants
    {
        public static readonly string[] Activities = {
            "Pooping... secretly.",
            "Waiting for the elevator.",
            "Doing some serious work. Do not disturb.",
            "Taking a break.",
            "Hiding under his desk from his boss.",
            "Browsing 9gag.",
            "Picking his nose.",
            "Working on a secret project."
        };

        public static readonly string defaultActivity = "Just came to work.";
        public static readonly string elevatorActivity = "Riding the elevator";
        public static readonly string exitingElevatorActivity = "Just gotten off the elevator";
    }
}
