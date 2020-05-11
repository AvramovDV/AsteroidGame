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
    /// Логика взаимодействия для NewDepartmentWindow.xaml
    /// </summary>
    public partial class NewDepartmentWindow : Window
    {
        public NewDepartmentWindow()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            MainWindow a = (MainWindow)Owner;
            a.AddDepartment(new Department(NametextBox.Text));
            this.Close();
        }

    }
}
