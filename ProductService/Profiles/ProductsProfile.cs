
using AutoMapper;
using ProductService.Models;
using ProductService.Dtos;

namespace ProductService.Profiles
{
    public class  ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            //Source to Target
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
        }
        
    }
}