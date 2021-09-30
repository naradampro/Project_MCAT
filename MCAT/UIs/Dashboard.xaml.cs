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

namespace MCAT.UIs
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        DashboardController cont = new DashboardController();
        public Dashboard()
        {
            InitializeComponent();
            LblTodayDate.Content = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            try
            {
                LblDriverCount.Content = cont.DriverCount();
                LblVehicleCount.Content = cont.VehicleCount();
                
                foreach (var record in cont.TodayReservation())
                {
                    DataGirdTodayReservations.Items.Add(record);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("MySQL Database connection not found. Plese check the databse connection and try again.", "MCAT Database not found.", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void OpenMakePayment(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new ModalPopups.MakePayment();
            ((MainWindow)Application.Current.MainWindow).NavDashboard.IsChecked = false;
        }

        private void OpenReserveVehicle(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new ModalPopups.ReserveVehicle();
            ((MainWindow)Application.Current.MainWindow).NavDashboard.IsChecked = false;
        }

        private void OpenPayments(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("View Payments is not available right now.", "Sorry", MessageBoxButton.OK, MessageBoxImage.Error);
            //((MainWindow)Application.Current.MainWindow).PageView.Content = new Payments();
            //((MainWindow)Application.Current.MainWindow).NavDashboard.IsChecked = false;
        }
    }
}
