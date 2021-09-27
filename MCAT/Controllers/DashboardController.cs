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

        public int DriverCount()
        {
           String sqlquery = "Select COUNT(*) From " + table2;
           return DBController.connect().ExecuteScalar<int>(sqlquery);
        }


        /// <summary>
        ///Number of Registered Vehicles
        /// </summary>
        public int VehicleCount()
        {
            String sqlquery = "Select COUNT(*) From " + table3;
            return DBController.connect().ExecuteScalar<int>(sqlquery);
        }

        /// <summary>
        ///Today Reservation Table
        /// </summary>

        public List<Reservation> TodayReservation()
        {
            string sqlquery = "SELECT r.id, r.pickuploc, c.fname, c.lname, c.mobileno, v.model, cat.catname, d.fname, d.lname, d.mobileno FROM reservation r INNER JOIN customer c ON r.cid = c.id INNER JOIN vehicle v ON r.vid = v.id INNER JOIN vcategory cat ON v.catid = cat.id INNER JOIN driver d ON v.did = d.id Where DATE(pickupdate)=CURDATE()";
            return DBController.connect().Query<Reservation, Customer, Vehicle, VCategory, Driver, Reservation>(sqlquery,
                (reserv, cust, vehic, vcat, driv) => {
                    reserv.Customer = cust;
                    reserv.Vehicle = vehic;
                    vehic.Category = vcat;
                    vehic.Driver = driv;
                    return reserv;
                }, splitOn: "fname,model,catname,fname").ToList();
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
