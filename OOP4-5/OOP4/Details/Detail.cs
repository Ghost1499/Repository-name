using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Details
{
    abstract class Detail : IDetail
    {
        public abstract int TimeShaping { get; }
        public abstract string Message { get; }
    }
}
