using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task1
{
    internal class WorkerFixSalary : AbstractWorker
    {
        public WorkerFixSalary(string name, float money) : base(name, money)
        {
        }

        public override float GetSalary() => BaseMoney;
        
    }
}
