using System;
using System.Windows;
using System.Windows.Controls;
using MCAT.Controllers;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    public partial class SearchCustomer : Page
    {
        CustomerController cont = new CustomerController();
        public SearchCustomer(Entities.Vehicle vehicle)
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                int mobile = Int32.Parse(TxtSearch.Text);
                Entities.Customer customer = cont.GetByMobile(mobile);
                if (customer==null)
                {
                    FormGrid.Visibility = Visibility.Hidden;
                    Notfound.Visibility = Visibility.Visible;
                    Entermsg.Visibility = Visibility.Hidden;
                    btnNext.IsEnabled = false;
                }
                else
                {
                    FormGrid.Visibility = Visibility.Visible;
                    Notfound.Visibility = Visibility.Hidden;
                    Entermsg.Visibility = Visibility.Hidden;
                    FormGrid.DataContext = customer;
                    btnNext.IsEnabled = true;
                }
            }
            catch (Exception ex) when (ex is OverflowException || ex is FormatException)
            {
                MessageBox.Show("Please enter a mobile number.", "Empty Mobile number");
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new AddCustomer();
        }
    }
}
