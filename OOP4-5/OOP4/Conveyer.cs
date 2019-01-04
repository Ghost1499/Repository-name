using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP4
{
    public class Conveyer
    {
        protected ProductionQueue production;
        protected IMechanic mechanic;
        protected Loader loader;
        protected DetailBase detailBase;
        protected Random rnd;
        protected int numberOfConveyer;

        public int NumberOfConveyer { get => numberOfConveyer; set => numberOfConveyer = value; }

        public Conveyer(int maxDetailsCount, DetailBase detailBase, int numberOfConveyer)
        {
            rnd = new Random();

            this.numberOfConveyer = numberOfConveyer;
            production = new ProductionQueue(maxDetailsCount);
            production.OutOfDetails += OutOfDetails;
            //mechanic
            this.detailBase = detailBase;
            loader = new Loader(detailBase,maxDetailsCount);
            loader.LoadCompleted +=LoadCompleted;
        }
        public delegate void MyMessageHandler(string message);
        public delegate void BreakHandler();
        public event MyMessageHandler SendMessage;
        public event BreakHandler AskMechanic;
        
        public virtual void StartConveyer(IMechanic mechanic)
        {
            //Thread secThread = new Thread(new ParameterizedThreadStart(ShapeDetail));
            //secThread.Start(production.DequeueDetail());
            this.mechanic = mechanic;
            mechanic.ConveyerRepaired += ConveyerRepaired;

            loader.LoadDetails(production);
            //for (int i=0;i<production.MaxDetailsCount;i++)
            ShapeDetail(production.DequeueDetail());
        }
        protected void AddConveyerNumber(ref string message)
        {
            message = numberOfConveyer + " КОНВ: " + message;
        }
        protected void OutOfDetails(string message)
        {
            AddConveyerNumber(ref message);
            SendMessage(message);
            loader.LoadDetails(production);
        }
        protected void QueueIsFull(string message)
        {
            AddConveyerNumber(ref message);
            SendMessage(message);
        }
        protected void LoadCompleted(string message)
        {
            AddConveyerNumber(ref message);
            SendMessage(message);
        }
        protected void ConveyerRepaired(string message)
        {
            AddConveyerNumber(ref message);
            SendMessage(message);
        }
        protected virtual void ShapeDetail(object obj)
        {
            TestConveyer();
            IDetail detail = obj as IDetail;
            Thread.Sleep(detail.TimeShaping);
            IDetail newdetail= production.DequeueDetail();
            string message = detail.Message;
            AddConveyerNumber(ref message);
            SendMessage(message);
            ShapeDetail(newdetail);
        }

        protected void TestConveyer()
        {
            string message = "Конвейер сломался";
            AddConveyerNumber(ref message);
            int breakNumber= rnd.Next(0, 10);
            if (breakNumber == 0)
            {
                SendMessage(message);
                AskMechanic();
            }
        }
        //private void
    }
}
