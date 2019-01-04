using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Details
{
    class SquareDetail:Detail
    {
        public SquareDetail()
        {
            TimeShaping = 1000;
        }
        public override string Message { get { return "Квадартная деталь обработана"; } }
        public override int TimeShaping { get; }
        
    }
}
