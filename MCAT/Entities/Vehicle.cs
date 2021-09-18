
namespace MCAT.Entities
{
    class Vehicle
    {

        //Vehicle ID
        private int id;

        //Vehicle Category ID
        private int catid;

        //Vehicle Register Number
        private int vregno;

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

        public Vehicle()
        {

        }

        public Vehicle(int id, int catid, int vregno, string fuelType, string lsdate, string nsdate, string acsatus, string description, int vstatus)
        {
            this.id = id;
            this.catid = catid;
            this.vregno = vregno;
            this.fuelType = fuelType;
            this.lsdate = lsdate;
            this.nsdate = nsdate;
            this.acsatus = acsatus;
            this.description = description;
            this.vstatus = vstatus;
        }

        public Vehicle(int catid, int vregno, string fuelType, string lsdate, string nsdate, string acsatus, string description, int vstatus)
        {
            this.catid = catid;
            this.vregno = vregno;
            this.fuelType = fuelType;
            this.lsdate = lsdate;
            this.nsdate = nsdate;
            this.acsatus = acsatus;
            this.description = description;
            this.vstatus = vstatus;
        }

        public int Id { get => id; set => id = value; }
        public int Catid { get => catid; set => catid = value; }
        public int Vregno { get => vregno; set => vregno = value; }
        public string FuelType { get => fuelType; set => fuelType = value; }
        public string Lsdate { get => lsdate; set => lsdate = value; }
        public string Nsdate { get => nsdate; set => nsdate = value; }
        public string Acstatus { get => acstatus; set => acstatus = value; }
        public string Description { get => description; set => description = value; }
        public int Vstatus { get => vstatus; set => vstatus = value; }
    }
       
}
