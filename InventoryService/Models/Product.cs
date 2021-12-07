using System.ComponentModel.DataAnnotations;

namespace InventoryService.Models
{
    public class Product 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string ? Name { get; set; }

        public ICollection<Inventory> ? Invetory { get; set; } = new List<Inventory>();


    }
}