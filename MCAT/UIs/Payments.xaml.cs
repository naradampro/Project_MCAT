using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MCAT.Controllers;
using MCAT.Entities;

namespace MCAT.UIs
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Payments : Page
    {
        CustomerController cont = new CustomerController();
        public Payments()
        {
            InitializeComponent();
            foreach (var record in cont.GetAll())
            {
                DataGridCustomers.Items.Add(record);
            }

        }

        private void OpenMakePayment(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new ModalPopups.MakePayment();
            ((MainWindow)Application.Current.MainWindow).NavDashboard.IsChecked = false;
        }
    }
}
