using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Details
{
    class SphereDetail:Detail
    {
        public SphereDetail()
        {
            TimeShaping = 3000;
        }
        public override string Message { get { return "Сферическая деталь обработана"; } }
        public override int TimeShaping { get; }
    }
}
