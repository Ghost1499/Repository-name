using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class Loader
    {
        private List<IDetail> details;
        private DetailBase detailBase;
        int capacity;
        public Loader(DetailBase detailBase, int capacity)
        {
            this.capacity = capacity;
            this.detailBase = detailBase;
            details = new List<IDetail>();
            TakeDetailsFromBase();
        }
        public delegate void LoadHandler(string message);
        public event LoadHandler LoadCompleted;

        public List<IDetail> Details { get => details; set => details = value; }


        public void LoadDetails(ProductionQueue productionQueue)
        {
            productionQueue.LoadQueue(details);
            TakeDetailsFromBase();
            LoadCompleted("Загрузка деталей завершена");
        }

        private void TakeDetailsFromBase()
        {
            for (int i = 0; i < capacity; i++)
            {
                details.Add(detailBase.DequeueDetail());
            }
        }

    }
}
