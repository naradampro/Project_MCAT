
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
        private string acsatus;

        //Description
        private string description;

        //Status
        private int vstatus;

        public int Id { get => id; set => id = value; }
    }
       
}
