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
    /// Interaction logic for UpdateReservation.xaml
    /// </summary>
    public partial class UpdateReservation : Page
    {
        Entities.Reservation reservation = new Entities.Reservation();
        ReservationController cont = new ReservationController();
        public UpdateReservation(Entities.Reservation reservation)
        {
            this.reservation = reservation;
            InitializeComponent();
            FormGrid.DataContext = reservation;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (cont.Update(this.reservation))
            {
                MessageBox.Show("The Reservation Details Successfully Updated.");
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ViewReservation(this.reservation);
            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }
    }
}
