using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson5
{
    public class Department
    {
        private string _name;

        public string Name { get => _name; }

        public Department(string name)
        {
            _name = name;
        }
    }
}
