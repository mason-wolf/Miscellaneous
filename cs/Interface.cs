using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    interface InterfaceExample
    {
        void GetValue();

        int MovementTimer();
        int DirectionTimer();
    }

    class InterfaceUsage : InterfaceExample
    {
        void InterfaceExample.GetValue()
        {
            Console.WriteLine("Interface in use.");
            Console.ReadLine();
        }

        int InterfaceExample.MovementTimer()
        {
            return 10;
        }

        int InterfaceExample.DirectionTimer()
        {
            return 10;
        }
    }
}
