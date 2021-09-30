using System.Windows.Controls;
using MCAT.Entities;
using MCAT.Controllers;
using System.Windows;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        Customer customer = new Customer();
        Vehicle vehicle = new Vehicle();

        CustomerController cont = new CustomerController();

        public AddCustomer(Vehicle vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            FormGrid.DataContext = this.customer;
        }

        private void btnRegCustomer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cont.Add(this.customer))
            {
                MessageBox.Show("Done");
                ((MainWindow)Application.Current.MainWindow).PageView.Content = new AddReservation(this.customer,this.vehicle);
            }
            else
            {
                MessageBox.Show("Not saved");
            }
        }
    }
}
