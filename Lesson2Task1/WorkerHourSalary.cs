using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task1
{
    class WorkerHourSalary : AbstractWorker
    {
        private const float DaysCount = 20.8f;
        private const int HoursCount = 8;

        public WorkerHourSalary(string name, float money) : base(name, money)
        {
        }

        public override float GetSalary() => BaseMoney * DaysCount * HoursCount;
        
    }
}
