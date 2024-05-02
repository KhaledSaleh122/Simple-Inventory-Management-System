using MongoDB.Bson;
using SimpleInventoryManagementSystem.Domain.DatabaseManagemnt;
using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain.InventoryManagemnt
{
    internal class InventoryDBMongoDB : IInventoryDB
    {
        private readonly IMongoDB _database;

        public InventoryDBMongoDB()
        {
            _database = (IMongoDB)DatabaseFactory.GetDatabase(DatabaseType.MongoDB);
        }

        public Product AddProduct(string name, int price, int quantity)
        {
            var database = _database.GetDatabase();
            var productCollection = database.GetCollection<BsonDocument>("products");
            var product = new Product() { 
                Name = name,
                Price = price,
                Quantity = quantity
            };
            productCollection.InsertOne(new BsonDocument() {
                { "name" ,name },{ "price", price },{ "quantity",quantity }
            });
            Console.WriteLine("Inserted successfully");
            return product;
        }
    }
}
