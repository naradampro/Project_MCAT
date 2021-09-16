using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{
    class PaymentController
    {
        /// <summary>
        /// Name of the table to be manipulated.
        /// </summary>
        private string table = "payment";

        /// <summary>
        /// Add a payment record to DB
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>
        /// Returns <c>True</c> if the execution is successful.
        /// Else retuns <c>False</c>
        /// </returns>
        public bool Add(Payment payment)
        {
            try
            {
                 string valuelist = "@Rid,@Amount,@Date";
                 string fieldlist = "`rid`, `amount`, `date`";
                 string sqlquery = "INSERT INTO `payment` ("+fieldlist+") VALUES("+valuelist+"); SELECT CAST(SCOPE_IDENTITY() as int)";
                 var returnId = DBController.connect().Query<int>(sqlquery, payment).SingleOrDefault();
                 payment.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Fetch all record from payment table of DB
        /// </summary>
        /// <returns>A <c>List</c> of Payments</returns>
        public List<Payment> GetAll()
        {
            string sqlquery = "Select * From " + table;
            return DBController.connect().Query<Payment>(sqlquery).ToList();
        }


        /// <summary>
        /// To fetch payment object from DB with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Payment with given id</returns>
        public Payment GetById(int id)
        {
            string sqlquery = "Select * From " + table + " Where Id=@Id";
            return DBController.connect().Query<Payment>(sqlquery, new { Id = id }).FirstOrDefault();
        }


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public bool Update(Payment payment, string ColumnName)
        {
            string sqlquery = "UPDATE " + table + " SET " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = DBController.connect().Execute(sqlquery, payment);
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
