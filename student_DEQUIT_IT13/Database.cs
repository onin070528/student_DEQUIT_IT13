using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace student_DEQUIT_IT13
{
    public class Database
    {
        public static SqlConnection GetConnection()
        {
            
            string connectionString = "Data Source=UNUSUALNEO\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;";
            return new SqlConnection(connectionString);
        }
    }
}
