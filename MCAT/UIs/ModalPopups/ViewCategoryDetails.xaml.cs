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

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for ViewCategoryDetails.xaml
    /// </summary>
    public partial class ViewCategoryDetails : Page
    {
        public ViewCategoryDetails(Entities.VCategory vcat)
        {
            InitializeComponent();
            FormGrid.DataContext = vcat;
        }
    }
}
