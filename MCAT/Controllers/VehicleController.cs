using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{ 
    class VehicleController
    {
        /// <summary>
        /// Name of the table to be manipulated.
        /// </summary>
        private string table = "vehicle";

        /// <summary>
        /// Add a vehicle record to DB
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>
        /// Returns <c>True</c> if the execution is successful.
        /// Else retuns <c>False</c>
        /// </returns>
        public bool Add(Vehicle vehicle)
        {
            try
            {
                string valuelist = vehicle.Driver.Id+",@Vregno,@Model,@FuelType,@Lsdate,@Nsdate,@Acstatus,"+vehicle.Category.Id+",@Description";
                 string fieldlist = "`did`, `vregno`,`model`, `fueltype`, `lsdate`, `nsdate`, `acstatus`,`catid`,`description`";
                 string sqlquery = "INSERT INTO `vehicle` ("+fieldlist+") VALUES("+valuelist+ "); SELECT LAST_INSERT_ID()";
                 var returnId = DBController.connect().Query<int>(sqlquery, vehicle).SingleOrDefault();
                 vehicle.Id = returnId;
             }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Fetch all record from vehicle table of DB
        /// </summary>
        /// <returns>A <c>List</c> of Customers</returns>
        public List<Vehicle> GetAll()
        {
            string sqlquery = "SELECT * FROM vehicle v INNER JOIN vcategory cat ON v.catid = cat.id INNER JOIN driver d ON v.did = d.id";
            return DBController.connect().Query<Vehicle, VCategory, Driver, Vehicle>(sqlquery,
                (vehic, vcat, driv) => {
                    vehic.Category = vcat;
                    vehic.Driver = driv;
                    return vehic;
                }, splitOn: "id,id").ToList();
        }


        /// <summary>
        /// To fetch vehicle object from DB with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Vehicle with given id</returns>
        public Vehicle GetById(int id)
        {
            string sqlquery = "Select * From " + table + " Where Id=@Id";
            return DBController.connect().Query<Vehicle>(sqlquery, new { Id = id }).FirstOrDefault();
        }



        public List<Vehicle> GetAvaialableonDate(DateTime date)
        {
            string sqlquery = "SELECT* FROM vehicle v INNER JOIN vcategory cat ON v.catid = cat.id INNER JOIN driver d ON v.did = d.id WHERE v.id NOT IN(SELECT r.vid from reservation r WHERE pickupdate = '" + date.ToString("yyyy-MM-dd") + "')";
            return DBController.connect().Query<Vehicle, VCategory, Driver, Vehicle>(sqlquery,
                (vehic, vcat, driv) => {
                    vehic.Category = vcat;
                    vehic.Driver = driv;
                    return vehic;
                }, splitOn: "id,id").ToList();
        }


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public bool Update(Vehicle vehicle)
        {
            string sqlquery = @"UPDATE vehicle SET did = "+vehicle.Driver.Id+", Vregno = @Vregno, Model = @Model, FuelType = @FuelType, Lsdate = @Lsdate, Nsdate = @Nsdate, Acstatus = @Acstatus, catid = "+vehicle.Category.Id+", Description = @Description WHERE Id = @Id";
            var count = DBController.connect().Execute(sqlquery, vehicle);
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
