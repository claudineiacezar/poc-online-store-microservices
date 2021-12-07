namespace InventoryService.Dtos
{
    public class InventoryReadDto
    {
       public int Id { get; set; }
        public int ProductId { get; set; }
        public int Qtd { get; set; }
        public string ? Size { get; set; }
        public string ? Color { get; set; }

     

    }
}