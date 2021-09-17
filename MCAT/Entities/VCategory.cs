using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCAT.Entities
{
    class VCategory
    {
        //Vehicle Category ID
        private int id;

        //Passenger capacity
        private int pcapacity;

        //No of currently available vehicles
        private int avaivehicles;

        //Vehicle caetegory name
        private String catname;

        //Cost per 1km
        private Double costonekm;

        //Cost per 1 day with driver salary and other expenses
        private Double costoneday;  

        public int Id { get => id; set => id = value; }
        public int Pcapacity { get => pcapacity; set => pcapacity = value; }
        public int Avaivehicles { get => avaivehicles; set => avaivehicles = value; }
        public string Catname { get => catname; set => catname = value; }
        public double Costonekm { get => costonekm; set => costonekm = value; }
        public double Costoneday { get => costoneday; set => costoneday = value; }

        //parameterized constructors
        public VCategory(int id, int pcapacity, int avaivehicles, string catname, Double costonekm, Double costoneday)
        {
            this.id=id;
            this.pcapacity=pcapacity;
            this.avaivehicles=avaivehicles;
            this.catname=catname;
            this.costonekm=costonekm;
            this.costoneday=costoneday;
        }
    }
}




