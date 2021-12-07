using System.ComponentModel.DataAnnotations;

namespace InventoryService.Models
{
    public class Inventory
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Qtd { get; set; }
        public string ? Size { get; set; }
        public string ? Color { get; set; }

        //Navigation property
        public Product ? Product { get; set; }

    }
}