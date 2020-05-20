using System;
using System.Collections.Generic;
using System.Data;
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
using WCFClient.ServiceReference1;

namespace WCFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Department> _departments = new List<Department>();
        //private List<Employee> _employees = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            
            using(ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                DataSet dataSet = service.GetDataFromDB();

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Department _new = new Department(dataSet.Tables[0].Rows[i].Field<string>("Name"));
                    for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
                    {
                        if (dataSet.Tables[1].Rows[j].Field<string>("Department") == _new.Name)
                        {
                            _new.Employes.Add(new Employee(dataSet.Tables[1].Rows[j].Field<string>("Name")));
                        }
                    }
                    _departments.Add(_new);
                }

            }

            DepartmentsList.ItemsSource = _departments;
            //EmployeesList.ItemsSource = _departments[0].Employes;

        }
    }
}
