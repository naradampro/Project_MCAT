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
    /// Interaction logic for UpdateCategoryDetails.xaml
    /// </summary>    
    public partial class UpdateCategoryDetails : Page
    {

        Entities.VCategory vcat = new Entities.VCategory();
        VCategoryController cont = new VCategoryController();
        public UpdateCategoryDetails(Entities.VCategory vcat)
        {
            InitializeComponent();
            this.vcat = vcat;
            FormGrid.DataContext = vcat;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (cont.Update(this.vcat))
            {
                MessageBox.Show("The Category Details Successfully Updated.");
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewCategoryDetails(this.vcat);
            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }
    }
}
