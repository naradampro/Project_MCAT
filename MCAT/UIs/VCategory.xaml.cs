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
    /// Interaction logic for VCategory.xaml
    /// </summary>
    public partial class VCategory : Page
    {
        VCategoryController cont = new VCategoryController();
        public VCategory()
        {
            InitializeComponent();
            foreach (var record in cont.GetAll())
            {
                DataGridVcat.Items.Add(record);
            }

        }

        private void OpenAddVCat(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.AddCategory();
            ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
        }

        private void OpenViewVcat(object sender, RoutedEventArgs e)
        {
            Entities.VCategory vcat = (Entities.VCategory)DataGridVcat.SelectedItem;
            if (vcat == null)
            {
                _ = MessageBox.Show("Please select a vehicle category record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.ViewCategoryDetails(vcat);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }

        private void OpenUpdateVcat(object sender, RoutedEventArgs e)
        {
            Entities.VCategory vcat = (Entities.VCategory)DataGridVcat.SelectedItem;
            if (vcat == null)
            {
                _ = MessageBox.Show("Please select a vehicle category record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.UpdateCategoryDetails(vcat);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PageView.Content = new VCategory();
        }
    }
}
