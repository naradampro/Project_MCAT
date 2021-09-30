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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MCAT.Controllers;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for AddDriver.xaml
    /// </summary>
    public partial class AddDriver : Page
    {
        Entities.Driver driver = new Entities.Driver();
        DriverController cont = new DriverController();
        public AddDriver()
        {
            InitializeComponent();
            this.driver.Bdate = DateTime.Today;
            this.driver.Licexdate = DateTime.Today;
            FormGrid.DataContext = this.driver;
        }

        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            bool validate = String.IsNullOrEmpty(TxtFirstName.Text) || String.IsNullOrEmpty(TxtLastName.Text);
            if (validate)
            {
                MessageBox.Show("Please fill all required fields.", "Empty Fields.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (cont.Add(this.driver))
                {
                    MessageBox.Show("The Driver is Added Successfully.");
                    ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewDriver(this.driver);
                }
                else
                {
                    MessageBox.Show("An error occured. Please try again.");
                }
            }
        }
    }
}
