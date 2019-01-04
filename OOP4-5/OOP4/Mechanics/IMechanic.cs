using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP4
{
    public interface IMechanic
    {
        event Action<string> ConveyerRepaired;
        int TimeOfRepairing { get; }
        string Message { get; }
        //bool IsWork { get; set; }
    }
}
