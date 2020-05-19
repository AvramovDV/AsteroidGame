using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson6
{
    public class Department
    {
        [Key] public int Id { get; set; } 
        public string Name { get; set; }
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        
        public Department() { }

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
