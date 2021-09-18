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

namespace MCAT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageView.Content = new UIs.Dashboard();
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((RadioButton)e.Source).Uid);

            switch (index)
            {
                case 0:
                    PageView.Content = new UIs.Dashboard();
                    break;
                case 1:
                    PageView.Content = new UIs.Customers();
                    break;
                case 2:
                    PageView.Content = new UIs.Reservations();
                    break;
                case 3:
                    PageView.Content = new UIs.Drivers();
                    break;
                case 4:
                    PageView.Content = new UIs.Vehicles();
                    break;
                case 5:
                    PageView.Content = new UIs.VCategory();
                    break;
            }
        }

        public void Popup(object sender, RoutedEventArgs e)
        {
            string trigger = ((Button)e.Source).Name;

            switch (trigger)
            {
                case "BtnAddVCat":
                    FramePopup.Content = new UIs.ModalPopups.AddVehicle();
                    break;
                case "BtnAddDriver":
                    FramePopup.Content = new UIs.ModalPopups.AddDriver();
                    break;
            }

        }

    }
}
