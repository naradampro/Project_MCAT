using System;
using System.Windows;
using System.Windows.Controls;
using MCAT.Controllers;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for MakePayment.xaml
    /// </summary>
    public partial class MakePayment : Page
    {
        ReservationController cont = new ReservationController();
        public MakePayment()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            int resid = Int32.Parse(TxtSearch.Text);
            FormGrid.DataContext = cont.GetById(resid);
        }

        private void btnPaid_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Payment is not not successful. Try again.", "Sorry", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
