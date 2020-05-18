using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson6
{
    public class Employee //: INotifyPropertyChanged
    {
        [Key]public int Id { get; set; }

        private string _name;

        public Department Depart { get; set; }
               

        public string Name { get => _name; set => _name = value; }

        public Employee() { }

        public Employee(string name, Department department)
        {
            Name = name;
            Depart = department;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name} {Depart.Name}";
        }

    }
}
