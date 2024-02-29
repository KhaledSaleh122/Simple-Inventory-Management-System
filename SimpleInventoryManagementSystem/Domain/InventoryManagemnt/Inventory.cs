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
        private static List<Product> products = new List<Product>();
        internal static bool IsProductNameAlreadyUsed(String name) { 
            return products.Find((e) => e.Name == name) != null;
        }
        internal static Product AddProduct(String name,int price,int quantity) {
            Product product = new Product(name, price, quantity);
            products.Add(product);
            return product;
        }
    }
}
