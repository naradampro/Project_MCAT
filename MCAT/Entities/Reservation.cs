
namespace MCAT.Entities
{
    class Reservation
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
        private string pickupdate;

        //Pickup Time
        private string pickuptime;

        //Number of Days
        private int days;

        //Distance for travell
        private double distance;

        //Description
        private string description;

        //Status
        private int rstatus;


        
        public int Id { get => id; set => id = value; }
        public int Cid { get => cid; set => cid = value; }
        public int Vid { get => vid; set => vid = value; }
        public int Did { get => did; set => did = value; }
        public string Pickuplock { get => pickuploc; set => pickuploc = value; }
        public string Pickupdate { get => pickupdate; set => pickupdate = value; }
        public string Pickuptime { get => pickuptime; set => pickuptime = value; }
        public int Days { get => days; set => days = value; }
        public double Distance { get => distance; set => distance = value; }
        public string Description { get => description; set => description = value; }
        public int Rstatus { get => rstatus; set => rstatus = value; }
        

        public Reservation()
    }

}
