using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace WPFLesson6
{
    class Manager
    {
        private const int _count = 5;

        public ObservableCollection<Department> Departments { get; set; }

        public Manager()
        {
            Departments = new ObservableCollection<Department>();
            for (int i = 0; i < _count; i++)
            {
                Department a = new Department($"Отдел {i}");
                for (int j = 0; j < _count; j++)
                {
                    a.Employees.Add(new Employee($"Сотрудник {j + i * _count}", a));
                }
                Departments.Add(a);
            }
        }

        
    }
}
