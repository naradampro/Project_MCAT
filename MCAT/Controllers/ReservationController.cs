using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{
    class ReservationController
    {
        /// <summary>
        /// Name of the table to be manipulated.
        /// </summary>
        private string table = "reservation";

        /// <summary>
        /// Add a reservation record to DB
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>
        /// Returns <c>True</c> if the execution is successful.
        /// Else retuns <c>False</c>
        /// </returns>
        public bool Add(Reservation reservation)
        {
            /*try
            {*/
            string valuelist = reservation.Customer.Id + "," + reservation.Vehicle.Id + ", @Pickuploc,@Pickupdate,@Pickuptime,@Days,@Distance,@Description";
                string fieldlist = "`cid`, `vid`, `pickuploc`, `pickupdate`, `pickuptime`, `days`, `distance`, `description`";
                string sqlquery = "INSERT INTO `reservation` (" + fieldlist + ") VALUES(" + valuelist + "); SELECT LAST_INSERT_ID()";
                int returnId = DBController.connect().Query<int>(sqlquery, reservation).SingleOrDefault();
                reservation.Id = returnId;
            /*}
            catch (Exception ex)
            {
                return false;
            }*/
            return true;
        }


        /// <summary>
        /// Fetch all record from reservation table of DB
        /// </summary>
        /// <returns>A <c>List</c> of Customers</returns>
        public List<Reservation> GetAll()
        {
            string sqlquery = "SELECT * FROM reservation r INNER JOIN customer c ON c.id = r.cid INNER JOIN vehicle v ON r.vid = v.id INNER JOIN vcategory cat ON v.catid = cat.id INNER JOIN driver d ON v.did = d.id";
            return DBController.connect().Query<Reservation, Customer, Vehicle, VCategory, Driver, Reservation>(sqlquery,
                (reserv, cust, vehic, vcat, driv) => { 
                    reserv.Customer = cust;
                    reserv.Vehicle = vehic;
                    vehic.Category = vcat;
                    vehic.Driver = driv;
                    return reserv;
                }, splitOn: "id,id,id,id").ToList();
        }


        /// <summary>
        /// To fetch reservation object from DB with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Reservation with given id</returns>
        public Reservation GetById(int id)
        {
            string sqlquery = @"SELECT * FROM reservation r INNER JOIN customer c ON c.id = r.cid INNER JOIN vehicle v ON r.vid = v.id INNER JOIN vcategory cat ON v.catid = cat.id INNER JOIN driver d ON v.did = d.id Where r.id="+id;
            return DBController.connect().Query<Reservation, Customer, Vehicle, VCategory, Driver, Reservation>(sqlquery,
                (reserv, cust, vehic, vcat, driv) =>
                {
                    reserv.Customer = cust;
                    reserv.Vehicle = vehic;
                    vehic.Category = vcat;
                    vehic.Driver = driv;
                    return reserv;
                }, splitOn: "id,id,id,id").FirstOrDefault();
        }


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public bool Update(Reservation reservation)
        {
            string sqlquery = @"UPDATE reservation SET Pickuploc = @Pickuploc, Pickupdate = @Pickupdate, Pickuptime = @Pickuptime, Days = @Days, Distance = @Distance, Description = @Description WHERE Id = @Id";
            var count = DBController.connect().Execute(sqlquery, reservation);
            return count > 0;
        }


        /// <summary>
        /// Delete record using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var affectedrows = DBController.connect().Execute("DELETE FROM " + table + " WHERE Id=@Id", new { Id = id });
            return affectedrows > 0;
        }
    }
}
