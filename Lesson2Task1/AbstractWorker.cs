using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task1
{
    internal abstract class AbstractWorker : IComparable
    {
        public string Name { get; private set; }
        public float BaseMoney { get; private set; }

        protected AbstractWorker(string name, float money)
        {
            Name = name;
            BaseMoney = money;
        }

        public abstract float GetSalary();

        public int CompareTo(object obj)
        {
            AbstractWorker worker = (AbstractWorker) obj;
            if (worker.GetSalary() > GetSalary())
            {
                return -1;
            }
            else if(worker.GetSalary() < GetSalary())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
