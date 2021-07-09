using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorSecuritySystemApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemSecurity systemSecurity = new SystemSecurity();
            DoorStatusHandler _addressOfNotification = new DoorStatusHandler(systemSecurity.Notification);


            DoorSensor _doorSensor = new DoorSensor();
            _doorSensor.OnDoorStatusChanged += _addressOfNotification;
            _doorSensor.DoorOpean();
            _doorSensor.DoorClosed();
            Console.ReadKey();
        }
    }
}
