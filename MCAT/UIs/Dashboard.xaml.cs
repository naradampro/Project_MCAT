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
            LblDriverCount.Content = cont.DriverCount();
            LblVehicleCount.Content = cont.VehicleCount();
            DataGirdTodayReservations.ItemsSource = cont.TodayReservation();
        }
    }
}
