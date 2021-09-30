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
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Page
    {
        VCategoryController cat = new VCategoryController();
        DriverController dri = new DriverController();
        Entities.Vehicle vehicle = new Entities.Vehicle();        
        VehicleController cont = new VehicleController();
        
        public AddVehicle()
        {
            InitializeComponent();
            ComboCategory.ItemsSource = cat.GetAll();
            ComboDriver.ItemsSource = dri.GetAll();
            this.vehicle.Lsdate = DateTime.Today;
            this.vehicle.Nsdate = DateTime.Today;
            FormGrid.DataContext = vehicle;
        }

        private void btnAddVehicle_Click(object sender, RoutedEventArgs e)
        {
            Entities.VCategory cat = (Entities.VCategory)ComboCategory.SelectedItem;
            Entities.Driver driver = (Entities.Driver)ComboDriver.SelectedItem;
            ComboBoxItem ac = ((ComboBoxItem)ComboAc.SelectedItem);
            if (ac == null || driver==null || cat == null || String.IsNullOrEmpty(TxtModel.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Empty Fields.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.vehicle.Category = cat;
                this.vehicle.Driver = driver;
                this.vehicle.Acstatus = ac.Content.ToString();
                if (cont.Add(this.vehicle))
                {
                    MessageBox.Show("The Vehicle Added Successfully.");
                    ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewVehicle(this.vehicle);                    
                }
                else
                {
                    MessageBox.Show("An error occured. Please try again.");
                }
            }
        }
    }
}
