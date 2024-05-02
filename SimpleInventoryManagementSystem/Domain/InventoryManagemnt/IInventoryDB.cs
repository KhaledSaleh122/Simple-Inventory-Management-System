using SimpleInventoryManagementSystem.Domain.ProductManagement;

namespace SimpleInventoryManagementSystem.Domain.InventoryManagemnt
{
    internal interface IInventoryDB
    {
        Product AddProduct(String name, int price, int quantity);
    }
}