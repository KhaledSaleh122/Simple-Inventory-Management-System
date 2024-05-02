using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain.DatabaseManagemnt
{
    internal class DatabaseFactory
    {
        public static IDatabase GetDatabase(DatabaseType type)
        {
            if (type == DatabaseType.SQLServer)
            {
                return new DatabaseSQLServer();
            }
            else if (type == DatabaseType.MongoDB)
            {
                return new DatabaseMongoDB();
            }
            else
            {
                throw new Exception("Unknown Type");
            }
        }
    }
}
