using System.Windows.Controls;
using MCAT.Entities;
using MCAT.Controllers;
using System.Windows;
using System;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        Customer customer = new Customer();
        Vehicle vehicle = new Vehicle();
        DateTime rdate;
        CustomerController cont = new CustomerController();

        public AddCustomer(Vehicle vehicle, DateTime rdate)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            this.rdate = rdate;
            FormGrid.DataContext = this.customer;
        }

        private void btnRegCustomer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cont.Add(this.customer))
            {
                MessageBox.Show("Done");
                ((MainWindow)Application.Current.MainWindow).PageView.Content = new AddReservation(this.customer,this.vehicle, this.rdate);
            }
            else
            {
                MessageBox.Show("Not saved");
            }
        }
    }
}
