using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain.DatabaseManagemnt
{
    public class Database
    {
        private string connectionString = "Server=; Database=SimpleInventory; Integrated Security=True;";
        SqlConnection SqlConnection { get; }
        public Database()
        {
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
        }
        public SqlConnection GetSqlConnection()
        {
            return SqlConnection;
        }


        public void CloseSqlConnection()
        {
            SqlConnection.Close();
        }
    }
}
