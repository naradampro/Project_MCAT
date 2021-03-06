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
            foreach (var record in cont.GetAll())
            {
                DataGridDrivers.Items.Add(record);
            }
        }

        private void OpenAddDriver(object sender, RoutedEventArgs e)
        {
            Entities.Driver driver = (Entities.Driver)DataGridDrivers.SelectedItem;
            ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.AddDriver();
            ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
        }

        private void OpenViewDriver(object sender, RoutedEventArgs e)
        {
            Entities.Driver driver = (Entities.Driver)DataGridDrivers.SelectedItem;
            if (driver == null)
            {
                _ = MessageBox.Show("Please select a driver record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.ViewDriver(driver);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }
            
        }

        private void OpenUpdateDriver(object sender, RoutedEventArgs e)
        {
            Entities.Driver driver = (Entities.Driver)DataGridDrivers.SelectedItem;
            if (driver == null)
            {
                _ = MessageBox.Show("Please select a driver record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.UpdateDriver(driver);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new Drivers();
        }
    }
}
