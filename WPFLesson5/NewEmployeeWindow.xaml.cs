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
using System.Windows.Shapes;

namespace WPFLesson5
{
    /// <summary>
    /// Логика взаимодействия для NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        public NewEmployeeWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            MainWindow a = (MainWindow) Owner;
            a.AddEmployee(new Employee(NametextBox.Text, a.Departments[DepartmentcomboBox.SelectedIndex]));
            this.Close();
        }
    }
}
