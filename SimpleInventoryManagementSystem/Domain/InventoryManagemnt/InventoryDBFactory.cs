using SimpleInventoryManagementSystem.Domain.DatabaseManagemnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain.InventoryManagemnt
{
    internal class InventoryDBFactory
    {
        public static IInventoryDB GetInventoryDB(DatabaseType type)
        {
            if (type == DatabaseType.SQLServer)
            {
                return new InventoryDBSQLServer();
            }
            else if (type == DatabaseType.MongoDB)
            {
                return new InventoryDBMongoDB();
            }
            else
            {
                throw new Exception("Unknown Type");
            }

        }
    }
}
