
using System;

namespace MCAT.Entities
{
    public class Reservation
    {
        //Reservation ID
        private int id;

        //Customer ID
        private int cid;

        //Vehicle ID
        private int vid;

        //Driver ID
        private int did;

        //Pickup Location
        private string pickuploc;

        //Pickup Date
        private DateTime pickupdate;

        //Pickup Time
        private TimeSpan pickuptime;

        //Number of Days
        private int days;

        //Distance for travell
        private double distance;

        //Description
        private string description;

        //Status
        private int rstatus;

        private Customer customer;
        private Vehicle vehicle;


        //default constructors
        public Reservation()
        {

        }

        public int Id { get => id; set => id = value; }
        public string CName { get => customer.Fname+" "+customer.Lname;}
        public int CMobileno { get => this.customer.Mobileno; }
        public string Vmodel { get => vehicle.Model; }
        public string Catname { get => vehicle.Category.Catname; }
        public string DName { get => vehicle.Driver.Fname + " " + Vehicle.Driver.Lname; }
        public string Pickuploc { get => pickuploc; set => pickuploc = value; }
        public DateTime Pickupdate { get => pickupdate; set => pickupdate = value; }
        public TimeSpan Pickuptime { get => pickuptime; set => pickuptime = value; }
        public int Days { get => days; set => days = value; }
        public double Distance { get => distance; set => distance = value; }
        public string Description { get => description; set => description = value; }
        public int Rstatus { get => rstatus; set => rstatus = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        internal Vehicle Vehicle { get => vehicle; set => vehicle = value; }
    }

}
