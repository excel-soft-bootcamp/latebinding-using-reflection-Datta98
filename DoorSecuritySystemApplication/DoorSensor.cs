using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Thread.Sleep(3000);
            this.Notify();
        }

        public void Notify()
        {
            string message = $"Door {this.doorStatus} and Time : {System.DateTime.Now.ToString()}";
            OnDoorStatusChanged.Invoke(message);
          
        }


    }
}
