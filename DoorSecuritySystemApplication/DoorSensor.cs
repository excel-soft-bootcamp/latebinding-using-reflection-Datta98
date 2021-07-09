using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorSecuritySystemApplication
{

    public delegate void DoorStatusHandler(string status);
     public class DoorSensor
    {
        string doorStatus ;
        public event DoorStatusHandler OnDoorStatusChanged;
        public void  DoorOpean()
        {
            doorStatus = "opened";

            this.Notify();

        }
        public void DoorClosed()
        {
            doorStatus = "closed";

            this.Notify();
        }

        public void Notify()
        {            
            OnDoorStatusChanged.Invoke(this.doorStatus);
          
        }


    }
}
