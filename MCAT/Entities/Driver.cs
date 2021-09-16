using System;

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
        private DateTime bdate;

        //License ID
        private int lid;

        //License Type
        private string lictype;

        //License Expire Date
        private DateTime licexdate;

        //Driver Status
        private int dstatus;

        public int Id { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public int Mobileno { get => mobileno; set => mobileno = value; }
        public string Nic { get => nic; set => nic = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public int Lid { get => lid; set => lid = value; }
        public string Lictype { get => lictype; set => lictype = value; }
        public int Dstatus { get => dstatus; set => dstatus = value; }
        public DateTime Licexdate { get => licexdate.Date; set => licexdate = value; }
        public DateTime Bdate { get => bdate; set => bdate = value; }
    }
}
