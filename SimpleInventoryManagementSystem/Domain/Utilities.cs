using SimpleInventoryManagementSystem.Domain.InventoryManagemnt;
using SimpleInventoryManagementSystem.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.Domain
{
    internal class Utilities
    {
        internal static void ShowMainMenu()
        {
            String userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Wellcome to Inventory Management System");
                Console.WriteLine();
                Console.WriteLine("**Select an Action from the Menu**");
                Console.WriteLine();
                Console.WriteLine("1: Add a product");
                Console.WriteLine("2: View all products");
                Console.WriteLine("3: Edit a product");
                Console.WriteLine("4: Delete a product");
                Console.WriteLine("5: Search for a product");
                Console.WriteLine("0: Close the application");
                userInput = Console.ReadLine();
                switch (userInput) {
                    case "1":
                        ShowAddProductMenu();break;
                    case "2":
                        ShowAllProducts();break;
                    case "3":
                        ShowEditProductMenu();break;
                    case "4":
                        //ShowDeleteProductMenu();break;
                    case "5":
                        //ShowSearchForProductMenu();break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("You selected wrong option, Try again.");
                        break;
                }
            } while (userInput != "0");
        }
        internal static void ShowEditProductMenu() {
            String userInput;
            do { 
                Console.WriteLine();
                Console.WriteLine("Enter name of product you want to edit: (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Invaild Input");
                    continue;
                }
                else if (userInput == "~")
                {
                    return;
                }

            } while (userInput != "~");
        }
        internal static void ShowAllProducts()
        {
            Inventory.DisplayProducts();
            Console.WriteLine("\nPress enter to back");
            Console.ReadLine();
        }
        private static void ShowAddProductMenu()
        {
            String userInput;
            String name = String.Empty;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter The Product Name: (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Invaild Input");
                    continue;
                }
                else if (userInput == "~")
                {
                    return;
                }
                //Check if name allready exist
                if (Inventory.IsProductNameAlreadyUsed(userInput)) {
                    Console.WriteLine("There already product with this name.");
                    continue;
                }
                name = userInput;
            } while (String.IsNullOrEmpty(name));
            int price = -1;
            do
            {
                Console.WriteLine("Enter The Product Price: (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                bool sucess = int.TryParse(userInput, out int price_);
                if (!sucess)
                {
                    Console.WriteLine("Invaild Input");
                    continue;
                }
                price = price_;
                if (userInput == "~")
                {
                    return;
                }
                if (price < 0) {
                    Console.WriteLine("Price must be bigger or equal to zero");
                    continue;
                }
            } while (price < 0);
            int quantity = -1;
            do
            {
                Console.WriteLine("Enter The Product Quantity: (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                bool sucess = int.TryParse(userInput, out int quantity_);
                if (!sucess)
                {
                    Console.WriteLine("Invaild Input");
                    continue;
                }
                quantity = quantity_;
                if (userInput == "~")
                {
                    return;
                }
                if (quantity < 0)
                {
                    Console.WriteLine("Quantity must be bigger or equal to zero");
                    continue;
                }
            } while (quantity < 0);
            //add item to inventory
            Product product =  Inventory.AddProduct(name, price, quantity);
            Console.WriteLine("\nYou successfully created a new product\n");
            Console.WriteLine(product);
            Console.WriteLine("\nPress enter to back");
            Console.ReadLine();
        }
    }
}
