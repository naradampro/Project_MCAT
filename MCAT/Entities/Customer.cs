
namespace MCAT.Entities
{
    class Customer
    {
        private int cid;
        private string address;
        private string lname;
        
        

        public int Cid { get => cid; set => cid = value; }
        public string Address { get => address; set => address = value; }
        public string Lname { get => lname; set => lname = value;}

    }
}
