using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{
    class DriverController
    {
        /// <summary>
        /// Name of the table to be manipulated.
        /// </summary>
        private string table = "driver";

        /// <summary>
        /// Add a driver record to DB
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>
        /// Returns <c>True</c> if the execution is successful.
        /// Else retuns <c>False</c>
        /// </returns>
        public bool Add(Driver driver)
        {
            try
            {
                string valuelist = "@Address,@Mobileno,@Nic,@Fname,@Lname,@Bdate,@Lid,@Licexdate";
                 string fieldlist = "`address`, `mobileno`, `nic`, `fname`, `lname`, `bdate`, `lid`, `licexdate`";
                 string sqlquery = "INSERT INTO `driver` ("+fieldlist+") VALUES("+valuelist+ "); SELECT LAST_INSERT_ID()";
                 var returnId = DBController.connect().Query<int>(sqlquery, driver).SingleOrDefault();
                 driver.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Fetch all record from driver table of DB
        /// </summary>
        /// <returns>A <c>List</c> of Customers</returns>
        public List<Driver> GetAll()
        {
            string sqlquery = "Select * From " + table;
            return DBController.connect().Query<Driver>(sqlquery).ToList();
        }


        /// <summary>
        /// To fetch driver object from DB with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Driver with given id</returns>
        public Driver GetById(int id)
        {
            string sqlquery = "Select * From " + table + " Where Id=@Id";
            return DBController.connect().Query<Driver>(sqlquery, new { Id = id }).FirstOrDefault();
        }


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public bool Update(Driver driver)
        {
            string sqlquery = @"UPDATE driver SET Address = @Address, Mobileno = @Mobileno, Nic = @Nic, Fname = @Fname, Lname = @Lname, Bdate = @Bdate, Lid = @Lid, Licexdate = @Licexdate WHERE Id = @Id";
            var count = DBController.connect().Execute(sqlquery, driver);
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
