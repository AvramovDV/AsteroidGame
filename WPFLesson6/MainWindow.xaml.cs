using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFLesson6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        Manager manager;
        public MainWindow()
        {
            InitializeComponent();
            manager = (Manager)TryFindResource("Manager");
            
        }

        
        public void DepartmentAddButtonClick(object sender, EventArgs e)
        {
            manager.Departments.Add(new Department(DepartmentNameTextBox.Text));
            
        }

        public void EmployeeAddButtonClick(object sender, EventArgs e)
        {
            if (DepartmentComboBox.SelectedIndex != -1)
            {
                manager.Departments[DepartmentComboBox.SelectedIndex].Employees.Add(new Employee(EmployeeNameTextBox.Text, (Department)DepartmentComboBox.SelectedItem));
            }
            else if (DepartmentsList.SelectedIndex != -1)
            {
                manager.Departments[DepartmentsList.SelectedIndex].Employees.Add(new Employee(EmployeeNameTextBox.Text, (Department)DepartmentsList.SelectedItem));
            }
        }

        public void SetDepartmentButtonClick(object sender, EventArgs e)
        {
            if (DepartmentComboBox.SelectedIndex != -1 && EmployeesList.SelectedIndex != -1)
            {
                Employee employee = (Employee) EmployeesList.SelectedItem;
                Department old = employee.Depart;
                Department _new = (Department) DepartmentComboBox.SelectedItem;
                employee.Depart = _new;
                old.Employees.Remove(employee);
                _new.Employees.Add(employee);
            }

        }

    }
}
