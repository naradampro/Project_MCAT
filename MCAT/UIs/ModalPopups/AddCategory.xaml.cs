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
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Page
    {
        VCategoryController cont = new VCategoryController();
        Entities.VCategory vcat = new Entities.VCategory();
        public AddCategory()
        {
            InitializeComponent();
            FormGrid.DataContext = vcat;
        }

        private void SaveToDB(object sender, RoutedEventArgs e)
        {
            if (cont.Add(vcat))
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Not saved");
            }
        }
    }
}
