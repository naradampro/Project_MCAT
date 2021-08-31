using System;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MCAT.Controllers
{
    class DBController
    {
        private static String server = ConfigurationManager.AppSettings["server"];
        private static String user = ConfigurationManager.AppSettings["user"];
        private static String password = ConfigurationManager.AppSettings["password"];
        private static String database = ConfigurationManager.AppSettings["database"];

        public static MySqlConnection connect()
        {
            string cs = @"server=" + server + ";userid=" + user + ";password=" + password + ";database=" + database + ";SSL Mode=0";

            using var con = new MySqlConnection(cs);
            con.Open();
            return con;
        }
    }
}