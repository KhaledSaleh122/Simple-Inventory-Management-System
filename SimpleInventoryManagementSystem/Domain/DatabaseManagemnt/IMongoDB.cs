using MongoDB.Driver;

namespace SimpleInventoryManagementSystem.Domain.DatabaseManagemnt
{
    internal interface IMongoDB
    {
        public IMongoDatabase GetDatabase();
    }
}