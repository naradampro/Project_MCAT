
namespace MCAT.Entities
{
    class Customer
    {
        //Customer ID
        private int cid;

        //Customer Address
        private string address;

        //Customer First Name
        private string fname;

        //Customer Last Name
        private string lname;

        //Customer Mobile Number
        private int mobileno;

        //Customer Status
        private int cstatus;

        //Customer NIC
        private string nic;
        
        

        public int Cid { get => cid; set => cid = value; }
        public string Address { get => address; set => address = value; }
        public string Fname { get => fname; set => fname = value;}
        public string Lname { get => lname; set => lname = value;}
        public int Mobileno { get => mobileno; set => mobileno = value; }
        public int Cstatus { get => cstatus; set => cstatus = value; }
        public string Nic { get => nic; set => nic = value; }
    }
}
