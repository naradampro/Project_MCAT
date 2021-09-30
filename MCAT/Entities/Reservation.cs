
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

        //Core Properties
        public int Id { get => id; set => id = value; }
        public int Cid { get => cid; set => cid = value; }
        public int Vid { get => vid; set => vid = value; }
        public int Did { get => did; set => did = value; }
        public string Vmodel { get => vehicle.Model; }
        public string Pickuploc { get => pickuploc; set => pickuploc = value; }        
        public int Days { get => days; set => days = value; }
        public double Distance { get => distance; set => distance = value; }
        public string Description { get => description; set => description = value; }
        public int Rstatus { get => rstatus; set => rstatus = value; }
        public DateTime Pickupdate { get => pickupdate; set => pickupdate = value; }
        public TimeSpan Pickuptime { get => pickuptime; set => pickuptime = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }        

        //Derived Properties
        public string Pickupdatestring { get => pickupdate.ToString("yyyy-MM-dd"); }

        public double Amount
        {
            get
            {
                return Distance * Vehicle.Category.Costonekm + Days * Vehicle.Category.Costoneday;
            }
        }
    }

}
