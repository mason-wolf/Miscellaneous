using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
   public class InheritanceExample
    {
        public string Value;

        public void GetValue()
        {
            Console.WriteLine(Value);
        }
    }

    class InheritanceUsage : InheritanceExample
    {
        public InheritanceUsage()
        {
            Value = "Inheritance in progress.";
        }
    }
}
