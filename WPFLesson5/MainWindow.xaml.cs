﻿using System;
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
                
        public List<Department> Departments { get => _departments; }
        public List<Employee> Emlpoyees { get => _employees; }

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

            ShowMyList();

        }

        private void ShowMyList()
        {
            EmployeesComboBox.ItemsSource = _employees.Select(a => a.Name);
            DepartmentsComboBox.ItemsSource = _departments.Select(a => a.Name);

            EmployeesComboBox.SelectedIndex = 0;
            DepartmentsComboBox.SelectedIndex = _departments.IndexOf(_employees[0].Department);
        }

        private void EmployeesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DepartmentsComboBox.SelectedIndex = _departments.IndexOf(_employees[EmployeesComboBox.SelectedIndex].Department);
        }

        private void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _employees[EmployeesComboBox.SelectedIndex].Department = _departments[DepartmentsComboBox.SelectedIndex];
        }

        private void NewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployeeWindow newEmploeeWindow = new NewEmployeeWindow();
            newEmploeeWindow.Owner = this;
            newEmploeeWindow.DepartmentcomboBox.ItemsSource = DepartmentsComboBox.ItemsSource;
            newEmploeeWindow.DepartmentcomboBox.SelectedIndex = 0;
            newEmploeeWindow.Show();
            

        }

        private void NewDepartment_Click(object sender, EventArgs e)
        {
            NewDepartmentWindow newDepartmentWindow = new NewDepartmentWindow();
            newDepartmentWindow.Owner = this;
            newDepartmentWindow.Show();
        }

        public void AddEmployee(Employee a)
        {
            _employees.Add(a);
            ShowMyList();
        }

        public void AddDepartment(Department a)
        {
            _departments.Add(a);
            ShowMyList();
        }

    }
}
