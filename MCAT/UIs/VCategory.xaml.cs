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

        private void OpenPopup(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Popup(sender,e);
            ((MainWindow)Application.Current.MainWindow).addCat.IsOpen = true;
        }
            
    }
}
