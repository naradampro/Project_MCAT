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
    /// Interaction logic for Vehicles.xaml
    /// </summary>
    public partial class Vehicles : Page
    {
        VehicleController cont = new VehicleController();

        public Vehicles()
        {
            InitializeComponent();
            DataGridaVehicles.ItemsSource = cont.GetAll();
        }

        private void OpenAddVehicle(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new UIs.ModalPopups.AddVehicle();
            ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
        }

        private void OpenViewVehicles(object sender, RoutedEventArgs e)
        {
            Entities.Vehicle vehicle = (Entities.Vehicle)DataGridaVehicles.SelectedItem;
            if (vehicle == null)
            {
                _ = MessageBox.Show("Please select a reservation record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.ViewVehicle(vehicle);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }

        private void OpenUpdateVehicle(object sender, RoutedEventArgs e)
        {
            Entities.Vehicle vehicle = (Entities.Vehicle)DataGridaVehicles.SelectedItem;
            if (vehicle == null)
            {
                _ = MessageBox.Show("Please select a reservation record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.UpdateVehicle(vehicle);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }
    }
}
