using AutoMapper;
using InventoryService.Dtos;
using InventoryService.Models;

namespace InventoryService.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            //Source -> Target
            CreateMap<Product, ProductReadDto>();
            CreateMap<InventoryCreateDto, Inventory>();
            CreateMap<Inventory, InventoryReadDto>();

        }
    }
}