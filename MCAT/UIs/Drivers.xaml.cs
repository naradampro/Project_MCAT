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
    /// Interaction logic for Drivers.xaml
    /// </summary>
    public partial class Drivers : Page
    {
        DriverController cont = new DriverController();
        public Drivers()
        {
            InitializeComponent();
            DataGridDrivers.ItemsSource = cont.GetAll();
        }

        private void OpenAddDriver(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).addDriver.IsOpen = true;
        }
    }
}
