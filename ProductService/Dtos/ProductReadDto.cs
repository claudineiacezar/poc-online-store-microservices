namespace ProductService.Dtos
{
    public class ProductReadDto
    {
    
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Publisher { get; set; }

        public double Price { get; set; }
    }
}