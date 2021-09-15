﻿using System;
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
            DataGridReservations.ItemsSource = cont.GetAll();
        }
 
    }
}
