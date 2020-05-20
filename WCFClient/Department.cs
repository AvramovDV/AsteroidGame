using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employes { get; set; } = new List<Employee>();

        public Department(string name)
        {
            Name = name;
        }
    }
}
