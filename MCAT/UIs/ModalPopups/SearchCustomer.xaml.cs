using System;
using System.Windows;
using System.Windows.Controls;
using MCAT.Controllers;
using MCAT.Entities;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    public partial class SearchCustomer : Page
    {
        CustomerController cont = new CustomerController();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();

        public SearchCustomer(Vehicle vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                int mobile = Int32.Parse(TxtSearch.Text);
                this.customer = cont.GetByMobile(mobile);
                if (customer==null)
                {
                    FormGrid.Visibility = Visibility.Hidden;
                    Notfound.Visibility = Visibility.Visible;
                    Entermsg.Visibility = Visibility.Hidden;
                    btnCountinue.Visibility = Visibility.Hidden;
                }
                else
                {
                    FormGrid.Visibility = Visibility.Visible;
                    Notfound.Visibility = Visibility.Hidden;
                    Entermsg.Visibility = Visibility.Hidden;
                    FormGrid.DataContext = this.customer;
                    btnCountinue.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) when (ex is OverflowException || ex is FormatException)
            {
                MessageBox.Show("Please enter a mobile number.", "Empty Mobile number");
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new AddCustomer(this.vehicle);
        }

        private void btnCountinue_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new AddReservation(this.customer, this.vehicle);
        }
    }
}
