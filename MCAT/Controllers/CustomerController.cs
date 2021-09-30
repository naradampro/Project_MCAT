using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{
    class CustomerController
    {
        /// <summary>
        /// Name of the table to be manipulated.
        /// </summary>
        private string table = "customer";

        /// <summary>
        /// Add a customer record to DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Returns <c>True</c> if the execution is successful.
        /// Else retuns <c>False</c>
        /// </returns>
        public bool Add(Customer customer)
        {
            try
            {
                string valuelist = "@Fname,@Lname,@Nic,@Address,@Mobileno";
                string fieldlist = "`fname`, `lname`, `nic`, `address`, `mobileno`";
                string sqlquery = "INSERT INTO `customer` (" + fieldlist + ") VALUES(" + valuelist + "); SELECT LAST_INSERT_ID()";
                var returnId = DBController.connect().Query<int>(sqlquery, customer).SingleOrDefault();
                customer.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Fetch all record from customer table of DB
        /// </summary>
        /// <returns>A <c>List</c> of Customers</returns>
        public List<Customer> GetAll()
        {
            string sqlquery = "Select * From " + table;
            return DBController.connect().Query<Customer>(sqlquery).ToList();
        }


        public Customer GetByMobile(int mobile)
        {
            string sqlquery = "SELECT * FROM customer c WHERE c.mobileno="+mobile;
            return DBController.connect().Query<Customer>(sqlquery).FirstOrDefault();
        }

        /// <summary>
        /// To fetch customer object from DB with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Customer with given id</returns>
        public Customer GetById(int id)
        {
            string sqlquery = "Select * From "+table+ " Where Id=@Id"; 
            return DBController.connect().Query<Customer>(sqlquery, new { Id = id }).FirstOrDefault();
        }


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public bool Update(Customer customer, string ColumnName)
        {
            string sqlquery = "UPDATE "+table+ " SET " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = DBController.connect().Execute(sqlquery, customer);
            return count > 0;
        }


        /// <summary>
        /// Delete record using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var affectedrows = DBController.connect().Execute("DELETE FROM "+table+" WHERE Id=@Id", new { Id = id });
            return affectedrows > 0;
        }
    }
}
