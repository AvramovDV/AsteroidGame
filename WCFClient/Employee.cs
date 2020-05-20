using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Employee
    {
        public string Name { get; set; }
        
        public Employee(string name)
        {
            Name = name;
        }
    }
}
