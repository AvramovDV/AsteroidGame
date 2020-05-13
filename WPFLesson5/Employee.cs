using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson5
{
    public class Employee
    {
        private string _name;
        private Department _department;

        public string Name { get => _name; }
        public Department Department { get => _department; set => _department = value; }

        public Employee(string name, Department department)
        {
            _name = name;
            _department = department;
        }

    }
}
