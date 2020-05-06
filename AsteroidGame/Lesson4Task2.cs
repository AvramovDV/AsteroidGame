using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class Lesson4Task2
    {
        private static List<int> listOfInt = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2, 1, 1, 1, 1, 1 };

        public static Dictionary<int, int> GetDoublesCount()
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            foreach (var item in listOfInt)
            {
                res[item] = listOfInt.FindAll(i => i == item).Count;
            }
            return res;
        }

    }
}
