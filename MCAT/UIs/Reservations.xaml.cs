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
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Page
    {
        ReservationController cont = new ReservationController();
        public Reservations()
        {
            InitializeComponent();            
            foreach (var record in cont.GetAll())
            {
                DataGridReservations.Items.Add(record);
            }
        }

        private void OpenAddReservation(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new UIs.ModalPopups.AddReservation();
            ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
        }

        private void OpenViewReservation(object sender, RoutedEventArgs e)
        {
            Entities.Reservation reservation = (Entities.Reservation)DataGridReservations.SelectedItem;
            if (reservation == null)
            {
                _ = MessageBox.Show("Please select a reservation record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.ViewReservation(reservation);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }

        private void OpenUpdateReservation(object sender, RoutedEventArgs e)
        {
            Entities.Reservation reservation = (Entities.Reservation)DataGridReservations.SelectedItem;
            if (reservation == null)
            {
                _ = MessageBox.Show("Please select a reservation record to view profile.", "No record selected.");
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).FramePopup.Content = new ModalPopups.UpdateReservation(reservation);
                ((MainWindow)Application.Current.MainWindow).modalviwer.IsOpen = true;
            }

        }
    }
}
