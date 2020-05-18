﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLesson6
{
    public class Employee //: INotifyPropertyChanged
    {
        private string _name;

        public Department Depart { get; set; }


        public string Name { get => _name; set => _name = value; }

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
