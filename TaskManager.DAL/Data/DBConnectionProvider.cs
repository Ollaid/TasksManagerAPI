using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Data
{
    public class DBConnectionProvider
    {
        public static SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection cnx = new SqlConnection("Data Source =.\\MSSQLSERVER2019; initial catalog = taskManager; Trusted_Connection = True; ");
                cnx.Open();
                return cnx;
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("OpenConnection: {0}", ex.Message));
            }
            
        } 
    }
}
