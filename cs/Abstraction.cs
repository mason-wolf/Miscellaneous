using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public abstract class AbstractionExample
    {
        abstract public void GetValue();
    }

    public class AbstractionUsage : AbstractionExample
    {
        public override void GetValue()
        {
            Console.WriteLine("Abstraction in progress.");
        }
    }
}
