using SimpleInventoryManagementSystem.Domain.DatabaseManagemnt;
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
                Console.WriteLine("Wellcome to Product Inventory Management System");
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
                switch (userInput)
                {
                    case "1":
                        ShowAddProductMenu(); break;
                    case "2":
                        ShowAllProducts(); break;
                    case "3":
                        ShowEditProductMenu(); break;
                    case "4":
                        ShowDeleteProductMenu(); break;
                    case "5":
                        ShowSearchForProductMenu(); break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("You selected wrong option, Try again.");
                        break;
                }
            } while (userInput != "0");
        }
        private static void ShowSearchForProductMenu()
        {
            String userInput;
            Product product = null;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter name of product you searching for: (ENTER ~ TO CANCEL THE OPERATION)");
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
                product = Inventory.GetProduct(userInput);
                if (product == null)
                {
                    Console.WriteLine("There's no product with this name");
                    Console.WriteLine("\nPress enter to back");
                    Console.ReadLine();
                    return;
                }
            } while (product == null);
            Console.WriteLine("\nProduct Found successfully\n");
            Console.WriteLine(product);
            Console.WriteLine("\nPress enter to back");
            Console.ReadLine();
        }
        private static void ShowDeleteProductMenu()
        {
            String userInput;
            Product product = null;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter name of product you want to delete: (ENTER ~ TO CANCEL THE OPERATION)");
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
                product = Inventory.GetProduct(userInput);
                if (product == null)
                {
                    Console.WriteLine("There's no product with this name");
                    continue;
                }
            } while (product == null);
            Inventory.DeleteProduct(product);
            Console.WriteLine("\nYou successfully deleted the product\n");
            Console.WriteLine(product);
            Console.WriteLine("\nPress enter to back");
            Console.ReadLine();
        }
        private static void ShowEditProductMenu()
        {
            String userInput;
            Product product = null;
            String name;
            int price;
            int quantity;
            do
            {
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
                product = Inventory.GetProduct(userInput);
                if (product == null)
                {
                    Console.WriteLine("There's no product with this name");
                    continue;
                }
            } while (product == null);

            do
            {
                Console.WriteLine($"Product with name {product.Name} found successfully");
                Console.WriteLine();
                Console.WriteLine($"Enter new name or press enter to keep current name ({product.Name}) : (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                name = product.Name;
                if (!String.IsNullOrEmpty(userInput) && userInput != product.Name)
                {
                    if (Inventory.IsProductNameAlreadyUsed(userInput))
                    {
                        Console.WriteLine("There already product with this name.");
                        continue;
                    }
                    name = userInput;
                }
                break;
            } while (userInput != "~");

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Enter new price or press enter to keep current price ({product.Price}) : (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    price = product.Price;
                    break;
                }
                else
                {
                    bool success = int.TryParse(userInput, out price);
                    if (!success)
                    {
                        Console.WriteLine("Invaild Input");
                        continue;
                    }
                    if (price < 0)
                    {
                        Console.WriteLine("Price must be bigger or equal to zero");
                        continue;
                    }
                }
            } while (price < 0);

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Enter new quantity or press enter to keep current quantity ({product.Quantity}) : (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                if (String.IsNullOrEmpty(userInput))
                {
                    quantity = product.Quantity;
                    break;
                }
                else
                {
                    bool success = int.TryParse(userInput, out quantity);
                    if (!success)
                    {
                        Console.WriteLine("Invaild Input");
                        continue;
                    }
                    if (quantity < 0)
                    {
                        Console.WriteLine("Price must be bigger or equal to zero");
                        continue;
                    }
                }
            } while (quantity < 0);
            //Edit current product data
            Inventory.UpdateProduct(product, name, price, quantity);
            Console.WriteLine("\nYou successfully edited the product info\n");
            Console.WriteLine(product);
            Console.WriteLine("\nPress enter to back");
            Console.ReadLine();

        }
        private static void ShowAllProducts()
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
                if (Inventory.IsProductNameAlreadyUsed(userInput))
                {
                    Console.WriteLine("There already product with this name.");
                    continue;
                }
                name = userInput;
            } while (String.IsNullOrEmpty(name));
            int price;
            do
            {
                Console.WriteLine("Enter The Product Price: (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                bool sucess = int.TryParse(userInput, out price);
                if (!sucess)
                {
                    Console.WriteLine("Invaild Input");
                    continue;
                }
                if (userInput == "~")
                {
                    return;
                }
                if (price < 0)
                {
                    Console.WriteLine("Price must be bigger or equal to zero");
                    continue;
                }
            } while (price < 0);
            int quantity;
            do
            {
                Console.WriteLine("Enter The Product Quantity: (ENTER ~ TO CANCEL THE OPERATION)");
                userInput = Console.ReadLine();
                bool sucess = int.TryParse(userInput, out quantity);
                if (!sucess)
                {
                    Console.WriteLine("Invaild Input");
                    continue;
                }
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
            var inventory = InventoryDBFactory.GetInventoryDB(DatabaseType.MongoDB);
            Product product = inventory.AddProduct(name, price, quantity);
            Console.WriteLine("\nYou successfully created a new product\n");
            Console.WriteLine(product);
            Console.WriteLine("\nPress enter to back");
            Console.ReadLine();
        }
    }
}
