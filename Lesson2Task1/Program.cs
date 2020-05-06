using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Task1
{
    class Program
    {
        private static AbstractWorker[] _workers = new AbstractWorker[4]
        {
            new WorkerFixSalary("Фред", 35000f),
            new WorkerHourSalary("Джон", 200f),
            new WorkerHourSalary("Стив", 300f),
            new WorkerFixSalary("Макс", 50000f)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("До сортировки");

            for (int i = 0; i < _workers.Length; i++)
            {
                Console.WriteLine($"{_workers[i].Name} получает в месяц: {_workers[i].GetSalary()}");
            }

            Array.Sort(_workers);

            Console.WriteLine("После сортировки");

            for (int i = 0; i < _workers.Length; i++)
            {
                Console.WriteLine($"{_workers[i].Name} получает в месяц: {_workers[i].GetSalary()}");
            }

            Console.ReadKey();
        }
    }
}
