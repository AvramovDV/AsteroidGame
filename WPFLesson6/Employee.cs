using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson6
{
    public class Employee
    {
        public Department Depart { get; set; }
        public string Name { get; set; }

        public Employee(string name, Department department)
        {
            Name = name;
            Depart = department;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
