
namespace MCAT.Entities
{
    class Customer
    {
        private int id;
        private string address;
        private string fname;
        private string lname;
        private int mobileno;
        private int cstatus;
        private string nic;
        
        

        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public string Fname { get => fname; set => fname = value;}
        public string Lname { get => lname; set => lname = value;}
        public int Mobileno { get => mobileno; set => mobileno = value; }
        public int Cstatus { get => cstatus; set => cstatus = value; }
        public string Nic { get => nic; set => nic = value; }
    }
}
