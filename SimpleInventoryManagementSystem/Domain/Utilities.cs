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
                        ShowDeleteProductMenu();break;
                    case "5":
                        ShowSearchForProductMenu();break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("You selected wrong option, Try again.");
                        break;
                }
            } while (userInput != "0");
        }
    }
}
