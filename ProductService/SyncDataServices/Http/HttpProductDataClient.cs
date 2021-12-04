using ProductService.Dtos;
using System.Text.Json;
using System.Text;

namespace ProductService.SyncDataServices.Http
{
    public class HttpProductDataClient : IProductDataClient
    {
        private readonly HttpClient _httpClient;

        public IConfiguration _configuration { get; }

        public HttpProductDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(ProductReadDto productReadDto)
        {
           var httpContent = new StringContent(
                JsonSerializer.Serialize(productReadDto),
                Encoding.UTF8,
                "application/json");
                
            var requestURL =_configuration["InventoryService"];
            Console.WriteLine($"--> REQUEST URL: {requestURL}");
            
            var response = await _httpClient.PostAsync($"{_configuration["InventoryService"]}", httpContent);
           
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> SYNC POST to Inventory was OK");
            }
            else
            {
                 Console.WriteLine("--> SYNC POST to Inventory was Not OK");
            }

           
        }
    }
}