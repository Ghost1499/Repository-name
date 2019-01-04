using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class ProductionQueue
    {
        private Queue<IDetail> details;
        private int maxDetailsCount;

        public ProductionQueue(int maxDetailsCount)
        {
            details = new Queue<IDetail>();
            this.maxDetailsCount = maxDetailsCount;
        }
        public delegate void CountOfDetailsHandler(string message);

        public event CountOfDetailsHandler OutOfDetails;

        public event CountOfDetailsHandler QueueIsFull;

        public IDetail DequeueDetail()
        {
            if (details.Count == 0)
            {
                OutOfDetails("Деталей нет");
            }
            return details.Dequeue();
        }
        public void LoadQueue(List<IDetail> alldetails)
        {
            for (int i = 0; i < maxDetailsCount; i++)
            {
                EnqueueDetail(alldetails[0]);
                alldetails.RemoveAt(0);
            }
        }
        private void EnqueueDetail(IDetail detail)
        {
            if (details.Count >= maxDetailsCount)
            {
                QueueIsFull("Очередь заполнена");
                return;
            }
            details.Enqueue(detail);
        }
        public Queue<IDetail> Details { get => details;}
        public int MaxDetailsCount { get => maxDetailsCount; set => maxDetailsCount = value; }

    }
}
