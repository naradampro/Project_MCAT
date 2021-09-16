using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MCAT.Entities;

namespace MCAT.Controllers
{
    class VCategoryController
    {
        /// <summary>
        /// Name of the table to be manipulated.
        /// </summary>
        private string table = "vcategory";

        /// <summary>
        /// Add Vehicle category record to DB
        /// </summary>
        /// <param name="category"></param>
        /// <returns>
        /// Returns <c>True</c> if the execution is successful.
        /// Else retuns <c>False</c>
        /// </returns>
        public bool Add(VCategory category)
        {
            try
            {
                string valuelist = "@Catname,@Pcapacity,@Costonekm,@Avaivehicles,@Costoneday";
                string fieldlist = "`catname`, `pcapacity`, `costonekm`, `avaivehicles`, `costoneday`";
                string sqlquery = "INSERT INTO `"+table+"` ("+fieldlist+") VALUES("+valuelist+"); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = DBController.connect().Query<int>(sqlquery, category).SingleOrDefault();
                category.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Fetch all record from vehicle category table of DB
        /// </summary>
        /// <returns>A <c>List</c> of Vehicle categories</returns>
        public List<VCategory> GetAll()
        {
            string sqlquery = "Select * From " + table;
            return DBController.connect().Query<VCategory>(sqlquery).ToList();
        }


        /// <summary>
        /// To fetch Vehicle category object from DB with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Vehicle category with given id</returns>
        public VCategory GetById(int id)
        {
            string sqlquery = "Select * From "+table+ " Where Id=@Id"; 
            return DBController.connect().Query<VCategory>(sqlquery, new { Id = id }).FirstOrDefault();
        }


        /// <summary>
        /// Updates a given column
        /// </summary>
        /// <param name="category"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public bool Update(VCategory category, string ColumnName)
        {
            string sqlquery = "UPDATE "+table+ " SET " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = DBController.connect().Execute(sqlquery, category);
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
