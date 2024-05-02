using SimpleInventoryManagementSystem.Domain.DatabaseManagemnt;
using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleInventoryManagementSystem.Domain.InventoryManagemnt
{
    internal class InventoryDBSQLServer : IInventoryDB
    {
        private readonly IDatabaseOpenClose _database;

        public InventoryDBSQLServer()
        {
            _database = (IDatabaseOpenClose)DatabaseFactory.GetDatabase(DatabaseType.SQLServer);
        }

        public Product AddProduct(String name, int price, int quantity)
        {
            string query = "INSERT INTO Products (name, price, quantity) VALUES (@name, @price, @quantity)";
            using (SqlCommand command = new SqlCommand(query, _database.GetSqlConnection()))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                int result = command.ExecuteNonQuery();
                if (result < 0)
                    new Exception("Error inserting data into Database!");
            }

            _database.CloseSqlConnection();
            var product = new Product(name, price, quantity);
            return product;
        }


    }
}
