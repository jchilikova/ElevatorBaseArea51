using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    public class SecurityChecker
    {
        public SecurityChecker()
        {
            
        }
        public bool CheckSecurityClearence(Floors floor, ClearenceTypes clearence)
        {
            switch (clearence)
            {
                case ClearenceTypes.Confidential:
                    if (floor == Floors.G)
                        return true;
                    else
                        return false;
                case ClearenceTypes.Secret:
                    if (floor == Floors.G || floor == Floors.S)
                        return true;
                    else
                        return false;
                case ClearenceTypes.TopSecret:
                    return true;
                default:
                    return false;
            }
        }
    }
}
