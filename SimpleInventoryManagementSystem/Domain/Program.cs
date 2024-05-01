// See https://aka.ms/new-console-template for more information
using SimpleInventoryManagementSystem.Domain.ProductManagement;
using SimpleInventoryManagementSystem.Domain.InventoryManagemnt;
using SimpleInventoryManagementSystem.Domain;
using SimpleInventoryManagementSystem.Domain.DatabaseManagemnt;
var databaseConnection = new Database();
//Inventory.AddProduct("Suger", 22, 1);
//Inventory.AddProduct("milk", 30, 100);
Utilities.ShowMainMenu();
