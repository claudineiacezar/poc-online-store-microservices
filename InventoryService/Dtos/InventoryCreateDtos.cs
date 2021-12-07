using System.ComponentModel.DataAnnotations;

namespace InventoryService.Dtos
{
    public class InventoryCreateDto
    {
        

        [Required]
        public int Qtd { get; set; }
        public string ? Size { get; set; }
        public string ? Color { get; set; }

    }
}