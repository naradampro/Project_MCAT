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
    /// Interaction logic for ReserveVehicle.xaml
    /// </summary>
    public partial class ReserveVehicle : Page
    {
        VCategoryController cat = new VCategoryController();
        VehicleController vcont = new VehicleController();
        DateTime date; 
        public ReserveVehicle()
        {
            InitializeComponent();
            ResultGrid.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
            ComboVCategory.ItemsSource = cat.GetAll();
        }

        private void SearchVehicles(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime sdate = (DateTime)Pickerdate.SelectedDate;
                this.date = sdate;
                entermsg.Visibility = Visibility.Hidden;
                ResultGrid.Visibility = Visibility.Visible;
                btnNext.Visibility = Visibility.Visible;
                ResultGrid.ItemsSource = vcont.GetAvaialableonDate(date);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Plese Select a date for reservation","Empty date",MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void OpenBookVehicle(object sender, RoutedEventArgs e)
        {
            Entities.Vehicle vehicle = (Entities.Vehicle)ResultGrid.SelectedItem;
            if (vehicle == null)
            {
                _ = MessageBox.Show("Please select a vehicle record to book.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).PageView.Content = new SearchCustomer(vehicle, this.date);
            }

        }
    }
}
