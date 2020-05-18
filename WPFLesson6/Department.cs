using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson6
{
    public class Department
    {
        public string Name { get; set; }
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
