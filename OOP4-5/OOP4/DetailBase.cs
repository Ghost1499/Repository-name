using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OOP4
{
    public class DetailBase
    {
        private Queue<IDetail> details;
        private Type type;

        public DetailBase(Type type, int maxnumber)
        {
            this.type = type;
            details = new Queue<IDetail>();
            for (int i = 0; i < maxnumber; i++)
            {
                ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                object detail =  constructor.Invoke(null);
                details.Enqueue((IDetail) detail);
            }
        }

        public Type Type {  set => type = value; }

        public IDetail DequeueDetail()
        {
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            object detail = constructor.Invoke(null);
            details.Enqueue((IDetail)detail);
            return details.Dequeue();
        }
    }
}
