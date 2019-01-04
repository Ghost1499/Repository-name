using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP4.Mechanics
{
    class GoodMechanic : IMechanic
    {
        private Conveyer conveyer;
        object locker;
        public GoodMechanic(Conveyer conveyer)
        {
            locker = new object();
            this.conveyer = conveyer;
            TimeOfRepairing = 500;
            Message = "Конвейер отремонтирован за " + TimeOfRepairing + " милисекунд";
            conveyer.AskMechanic += Repair;
        }

        public event Action<string> ConveyerRepaired;
        public int TimeOfRepairing { get; }

        public string Message { get; }

        private void Repair()
        {
            lock (locker)
            {
                Thread.Sleep(TimeOfRepairing);
                ConveyerRepaired(Message);
            }
        }
    }
}
