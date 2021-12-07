using InventoryService.Models;

namespace InventoryService.Data
{
    public class InventoryRepo : IInventoryRepo
    {
        private readonly AppDbContext _context;

        public InventoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public void createInventory(int productId, Inventory inventory)
        {
            if (inventory == null)
            {
                throw new ArgumentNullException(nameof(inventory));
            }
            inventory.ProductId = productId;
            _context.Inventory.Add(inventory);
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            
            _context.Products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Inventory GetInventory(int productId, int inventoryId)
        {
           return _context.Inventory
            .Where(i => i.ProductId == productId 
                && i.Id == inventoryId ).FirstOrDefault();
        }

        public IEnumerable<Inventory> GetInventoryForProduct(int productId)
        {
           return _context.Inventory
            .Where(i => i.ProductId == productId);
        }

        public bool ProductExist(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}