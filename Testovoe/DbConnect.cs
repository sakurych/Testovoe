using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class DbConnect
    {
        public SqlConnection sqlConnection;
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sakurych\source\repos\Testovoe\Testovoe\Database1.mdf;Integrated Security=True";
        public void ConnectSql()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}
