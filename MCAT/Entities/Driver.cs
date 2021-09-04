
namespace MCAT.Entities
{
    class Driver
    {
        //Driver ID
        private int id;

        //Driver Address
        private string address;

        //Driver Mobile number
        private int mobileno;

        //Driver NIC
        private string nic;

        //Driver First Name
        private string fname;

        //Driver Last Name
        private string lname;

        //Driver Birth Date
        private string bdate;

        //License ID
        private int lid;

        //License Type
        private string lictype;

        //License Expire Date
        private string licexdate;

        //Driver Status
        private int dstatus;

        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public int Mobileno { get => mobileno; set => mobileno = value; }
        public string Nic { get => nic; set => nic = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Bdate { get => bdate; set => bdate = value; }
        public int Lid { get => lid; set => lid = value; }
        public string Lictype { get => lictype; set => lictype = value; }
        public string Licexdate { get => licexdate; set => licexdate = value; }
        public int Dstatus { get => dstatus; set => dstatus = value; }
    }
}
