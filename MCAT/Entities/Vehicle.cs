
namespace MCAT.Entities
{
    public class Vehicle
    {

        //Vehicle ID
        private int id;

        //Vehicle Category ID
        private int catid;

        //Vehicle Register Number
        private string vregno;

        //Fuel Type of the vehicle
        private string fuelType;

        //Vehicle Last Service Date
        private string lsdate;

        //Vehicle Next Service Date
        private string nsdate;

        //Vehicle Status
        private string acstatus;

        //Description
        private string description;

        //Status
        private int vstatus;

        private string model;

        private VCategory category;
        private Driver driver;

        public Vehicle()
        {

        }

        public Vehicle(int id, int catid, string vregno, string fuelType, string lsdate, string nsdate, string acstatus, string description, int vstatus)
        {
            this.id = id;
            this.catid = catid;
            this.vregno = vregno;
            this.fuelType = fuelType;
            this.lsdate = lsdate;
            this.nsdate = nsdate;
            this.acstatus = acstatus;
            this.description = description;
            this.vstatus = vstatus;
        }

        public Vehicle(int catid, string vregno, string fuelType, string lsdate, string nsdate, string acstatus, string description, int vstatus)
        {
            this.catid = catid;
            this.vregno = vregno;
            this.fuelType = fuelType;
            this.lsdate = lsdate;
            this.nsdate = nsdate;
            this.acstatus = acstatus;
            this.description = description;
            this.vstatus = vstatus;
        }

        //Core Properties
        public int Id { get => id; set => id = value; }
        public int Catid { get => catid; set => catid = value; }
        public string Vregno { get => vregno; set => vregno = value; }
        public string FuelType { get => fuelType; set => fuelType = value; }
        public string Lsdate { get => lsdate; set => lsdate = value; }
        public string Nsdate { get => nsdate; set => nsdate = value; }
        public string Acstatus { get => acstatus; set => acstatus = value; }
        public string Description { get => description; set => description = value; }
        public int Vstatus { get => vstatus; set => vstatus = value; }
        public string Model { get => model; set => model = value; }
        public VCategory Category { get => category; set => category = value; }
        public Driver Driver { get => driver; set => driver = value; }
    }
       
}
