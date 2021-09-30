using System.Windows.Controls;
using MCAT.Entities;
using MCAT.Controllers;
using System.Windows;

namespace MCAT.UIs.ModalPopups
{
    /// <summary>
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Page
    {
        Reservation reservation = new Reservation();
        ReservationController cont = new ReservationController();

        public AddReservation(Customer customer, Vehicle vehicle)
        {
            InitializeComponent();
            this.reservation.Customer = customer;
            this.reservation.Vehicle = vehicle;
            FormGrid.DataContext = this.reservation;
        }

        private void btnAddResetrvation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (cont.Add(this.reservation))
            {
                MessageBox.Show("Your Reservation is successfully created.");
                ((MainWindow)Application.Current.MainWindow).PageView.Content = new ViewReservation(this.reservation);
            }
            else
            {
                MessageBox.Show("En error occurred. Please try agaain.");
            }
        }
    }
}
