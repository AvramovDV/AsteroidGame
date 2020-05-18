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
using System.Data.Entity;

namespace WPFLesson6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        private Manager _manager;
        public MainWindow()
        {
            InitializeComponent();
            _manager = (Manager)TryFindResource("Manager");

            using (var db = new ManagerDB())
            {
                //db.Database.Delete();
                db.Departments.AddRange(_manager.Departments);
                db.SaveChanges();
            }
        }

        
        public void DepartmentAddButtonClick(object sender, EventArgs e)
        {
            Department _new = new Department(DepartmentNameTextBox.Text);

            _manager.Departments.Add(_new);

            using (var db = new ManagerDB())
            {
                db.Departments.Add(_new);
                db.SaveChanges();
            }

        }

        public void EmployeeAddButtonClick(object sender, EventArgs e)
        {
            if (DepartmentComboBox.SelectedIndex != -1)
            {
                Department current = _manager.Departments[DepartmentComboBox.SelectedIndex];
                Employee _new = new Employee(EmployeeNameTextBox.Text, (Department)DepartmentComboBox.SelectedItem);

                current.Employees.Add(_new);

                using (var db = new ManagerDB())
                {
                    db.Employees.Add(_new);
                    db.SaveChanges();
                }

            }
            else if (DepartmentsList.SelectedIndex != -1)
            {
                Department current = _manager.Departments[DepartmentsList.SelectedIndex];
                Employee _new = new Employee(EmployeeNameTextBox.Text, (Department)DepartmentsList.SelectedItem);

                current.Employees.Add(_new);

                using (var db = new ManagerDB())
                {
                    db.Employees.Add(_new);
                    db.SaveChanges();                    
                }
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

                //using (var db = new ManagerDB())
                //{
                //    Employee empl = db.Employees.Where(res => res.Id == employee.Id).FirstOrDefault();
                //    Department dep = db.Departments.Where(res => res.Id == _new.Id).FirstOrDefault();
                //    empl.Depart = dep;
                //    db.SaveChanges();
                //}

            }

        }

    }
}
