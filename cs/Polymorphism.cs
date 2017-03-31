using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class PolymorphismExample
    {
        public void Print(string value)
        {
            Console.WriteLine(value);
        }

        public void Print(int value)
        {
            Console.WriteLine(value);
        }

        public void Print(float value)
        {
            Console.WriteLine(value);
        }
    }
}
