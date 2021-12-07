using InventoryService.Models;

namespace InventoryService.Data
{
    public interface IInventoryRepo
    {
        bool SaveChanges();
        // Products
        IEnumerable<Product> GetAllProducts();
        void CreateProduct (Product product);
        bool ProductExist(int productId);

        //Invetory
        IEnumerable<Inventory> GetInventoryForProduct(int productId);
        Inventory GetInventory(int productId, int inventoryId);
        void createInventory (int productId, Inventory inventory);

    }
};