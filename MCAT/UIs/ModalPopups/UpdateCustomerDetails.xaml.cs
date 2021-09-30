using System.Windows;
using System.Windows.Controls;
using MCAT.Controllers;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for UpdateCustomerDetails.xaml
    /// </summary>
    public partial class UpdateCustomerDetails : Page
    {
        CustomerController cont = new CustomerController();
        Entities.Customer customer = new Entities.Customer();
        public UpdateCustomerDetails(Entities.Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            FormGrid.DataContext = customer;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (cont.Update(this.customer))
            {
                MessageBox.Show("The Customer Details Successfully Updated.");
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewCustomerDetails(this.customer);
            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }
    }
}
