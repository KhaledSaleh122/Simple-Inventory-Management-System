using MongoDB.Driver;
using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain.DatabaseManagemnt
{
    public class DatabaseMongoDB : IDatabase, IMongoDB
    {
        MongoClient _client;
        public DatabaseMongoDB()
        {
            var connectionString = "mongodb://localhost:27017";
            _client = new MongoClient(connectionString);
        }
        public IMongoDatabase GetDatabase()
        {
            return _client.GetDatabase("SimpleInventory");
        }
    }
}
