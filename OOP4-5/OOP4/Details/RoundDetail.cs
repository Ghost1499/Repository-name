using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Details
{
    class RoundDetail:Detail
    {
        public RoundDetail()
        {
            TimeShaping = 1500;
        }
        public override string Message { get { return "Круглая деталь обработана"; } }
        public override int TimeShaping { get; }
    }
}
