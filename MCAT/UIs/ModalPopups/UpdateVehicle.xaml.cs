using System.Windows;
using System.Windows.Controls;
using MCAT.Controllers;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for UpdateVehicle.xaml
    /// </summary>
    public partial class UpdateVehicle : Page
    {
        VCategoryController cat = new VCategoryController();
        DriverController dri = new DriverController();
        Entities.Vehicle vehicle = new Entities.Vehicle();
        VehicleController cont = new VehicleController();

        public UpdateVehicle(Entities.Vehicle vehicle)
        {
            InitializeComponent();
            ComboCategory.ItemsSource = cat.GetAll();
            ComboDriver.ItemsSource = dri.GetAll();
            this.vehicle = vehicle;
            FormGrid.DataContext = vehicle;
            ComboCategory.SelectedValue = vehicle.Category.Id;
            ComboDriver.SelectedValue = vehicle.Driver.Id;
            ComboAc.SelectedValue = vehicle.Acstatus;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Entities.VCategory cat = (Entities.VCategory)ComboCategory.SelectedItem;
            Entities.Driver driver = (Entities.Driver)ComboDriver.SelectedItem;
            ComboBoxItem ac = ((ComboBoxItem)ComboAc.SelectedItem);
            if (ac == null || driver == null || cat == null || string.IsNullOrEmpty(TxtModel.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Empty Fields.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.vehicle.Category = cat;
                this.vehicle.Driver = driver;
                this.vehicle.Acstatus = ac.Content.ToString();
                if (cont.Update(this.vehicle))
                {
                    MessageBox.Show("The Vehicle Details Successfully Updated.");
                    ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewVehicle(this.vehicle);
                }
                else
                {
                    MessageBox.Show("An Error Occured.");
                }
            }
        }
    }
}
