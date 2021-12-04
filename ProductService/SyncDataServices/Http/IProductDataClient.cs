using ProductService.Dtos;

namespace ProductService.SyncDataServices.Http
{
    public interface IProductDataClient
    {
        Task SendPlatformToCommand(ProductReadDto productReadDto);

    }
}