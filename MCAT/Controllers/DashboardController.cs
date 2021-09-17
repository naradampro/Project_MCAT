using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{
    class DashboardController
    {
         /// <summary>
         ///Table Names
         /// </summary>
         private string table1 = "reservation";
         private string table2 = "driver";
         private string table3 = "vehicle";

        /// <summary>
        ///Number of Registered Drivers
        /// </summary>

        public Driver DriverCount()
        {
           String sqlquery = "Select COUNT(*) From " + table2;
            return null;
        }


        /// <summary>
        ///Number of Registered Vehicles
        /// </summary>
        public Driver VehicleCount()
        {
            String sqlquery = "Select COUNT(*) From " + table3;
            return null;
        }

        /// <summary>
        ///Today Reservation Table
        /// </summary>

        public List<Reservation> TodayReservation()
        {
            string sqlquery = "Select 'vid','pickuploc' From " + table1 + " Where DATE(pickupdate)=CURDATE()";
            return DBController.connect().Query<Reservation>(sqlquery).ToList();
        }

        /// <summary>
        ///Upcomming Reservation Table
        /// </summary>

        public List<Reservation> UpcommingReservation()
        {
            string sqlquery = "Select 'vid','pickuploc','pickupdate' From " + table1 + "Where DATE(pickupdate)>CURDATE() AND DATE(pickupdate)<CURDATE()+2 ";
            return DBController.connect().Query<Reservation>(sqlquery).ToList();
        }

    }
}
