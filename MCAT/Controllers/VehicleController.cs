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
                string valuelist = "@Vregno,@Fueltype,@Lsdate,Nsdate,Acstatus,@Catid,@Description,@Vstatus";
                 string fieldlist = "`vregno`, `fueltype`, `lsdate`, `nsdate`, `acstatus`,`catid`,`description`,`vstatus`";
                 string sqlquery = "INSERT INTO `vehicle` ("+fieldlist+") VALUES("+valuelist+"); SELECT CAST(SCOPE_IDENTITY() as int)";
                 var returnId = DBController.connect().Query<int>(sqlquery, vehicle).SingleOrDefault();
                 vehicle.Id = returnId;
            }
            catch (Exception ex)
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
            string sqlquery = "Select * From " + table;
            return DBController.connect().Query<Vehicle>(sqlquery).ToList();
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


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public bool Update(Vehicle vehicle, string ColumnName)
        {
            string sqlquery = "UPDATE " + table + " SET " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
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
