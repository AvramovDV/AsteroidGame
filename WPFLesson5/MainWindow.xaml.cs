using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFLesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Department> _departments;
        private List<Employee> _employees;

        public MainWindow()
        {
            InitializeComponent();
            MyListInI();
        }

        private void MyListInI()
        {
            _departments = new List<Department>(5);
            _departments.Add(new Department("Отдел 1"));
            _departments.Add(new Department("Отдел 2"));
            _departments.Add(new Department("Отдел 3"));
            _departments.Add(new Department("Отдел 4"));
            _departments.Add(new Department("Отдел 5"));

            _employees = new List<Employee>(5);
            _employees.Add(new Employee("Петров", _departments[0]));
            _employees.Add(new Employee("Иванов", _departments[1]));
            _employees.Add(new Employee("Сидоров", _departments[2]));
            _employees.Add(new Employee("Слащев", _departments[3]));
            _employees.Add(new Employee("Игнатьев", _departments[4]));
            
        }

    }
}
