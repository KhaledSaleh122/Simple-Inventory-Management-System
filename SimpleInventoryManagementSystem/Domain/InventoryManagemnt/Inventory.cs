using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInventoryManagementSystem.Domain.ProductManagement;
namespace SimpleInventoryManagementSystem.Domain.InventoryManagemnt
{
    internal class Inventory
    {
        internal static List<Product> products = new List<Product>();
        internal static bool IsProductNameAlreadyUsed(String name) { 
            return products.Find((e) => e.Name == name) != null;
        }
    }
}
