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
    public partial class Customers : Page
    {
        CustomerController cont = new CustomerController();
        public Customers()
        {
            InitializeComponent();
            foreach (var record in cont.GetAll())
            {
                DataGridCustomers.Items.Add(record);
            }

        }

        private void OpenAddCustomer(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new UIs.ModalPopups.AddCustomer();
            ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
        }

        private void OpenViewCustomers(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)DataGridCustomers.SelectedItem;
            if (customer == null)
            {
                _ = MessageBox.Show("Please select a customer record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.ViewCustomerDetails(customer);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }
        }

        private void OpenUpdateCustomer(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)DataGridCustomers.SelectedItem;
            if (customer == null)
            {
                _ = MessageBox.Show("Please select a customer record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.UpdateCustomerDetails(customer);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }
        }
    }
}
