
namespace MCAT.Entities
{
    class Customer
    {
        //customer id
        private int id;

        //customer address
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
        
        

        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public string Fname { get => fname; set => fname = value;}
        public string Lname { get => lname; set => lname = value;}
        public int Mobileno { get => mobileno; set => mobileno = value; }
        public int Cstatus { get => cstatus; set => cstatus = value; }
        public string Nic { get => nic; set => nic = value; }

        //default constructor
        public Customer()
        {

        }

        //parameterized constructors
        public Customer(int id, string address, string fname, string lname, int mobileno, int cstatus, string nic)
        {
            this.id=id;
            this.address=address;
            this.fname=fname;
            this.lname=lname;
            this.mobileno=mobileno;
            this.cstatus=cstatus;
            this.nic=nic;
        }

        //parameterized constructors without id
        public Customer( string address, string fname, string lname, int mobileno, int cstatus, string nic)
        {
            
            this.address=address;
            this.fname=fname;
            this.lname=lname;
            this.mobileno=mobileno;
            this.cstatus=cstatus;
            this.nic=nic;
        }
    }

    
}
