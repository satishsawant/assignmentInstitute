using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Repository
{
    class DataAccess
    {
        public static int ExecuteSPNonQuery(string connectionStringName, string procName, object poco)
        {
            int retVal;
            string con = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            using (SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand(procName, connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    retVal = command.ExecuteNonQuery();
                }
            }

            return retVal;
        }
    }
}
