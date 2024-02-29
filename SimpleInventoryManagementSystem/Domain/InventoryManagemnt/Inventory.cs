﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public static void DisplayProducts() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name  |  Price  |  Quantity\n");
            Console.WriteLine("{0,-15} | {1,-10} | {2,-8}", "Name", "Price", "Quantity");
            Console.WriteLine(new string('-', 40)); // Separator line
            if (products.Count == 0) {
                Console.WriteLine("No products in inventory yet");
                return;
            }
            foreach (Product product in products)
            {
                Console.WriteLine("{0,-15} | {1,-10} | {2,-8}", product.Name, product.Price, product.Quantity);
            }
        }
    }
}
