using System.Windows;
using System.Windows.Controls;
using MCAT.Controllers;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for UpdateDriver.xaml
    /// </summary>
    public partial class UpdateDriver : Page
    {
        Entities.Driver driver = new Entities.Driver();
        DriverController cont = new DriverController();

        public UpdateDriver(Entities.Driver driver)
        {
            InitializeComponent();
            this.driver = driver;
            FormGrid.DataContext = driver;
        }

        private void btnSaveChanges_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cont.Update(this.driver))
            {
                MessageBox.Show("The Driver Details Successfully Updated.");
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewDriver(this.driver);
            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }
    }
}
