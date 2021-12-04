using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.SyncDataServices.Http;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;

        public IProductDataClient _productDataClient { get; }

        public ProductsController(
            IProductRepo repository, 
            IMapper mapper,
            IProductDataClient productDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _productDataClient = productDataClient;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts ()
        {
            Console.WriteLine("--> Gettitng Products");
            var products = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));

        }
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id){
            var platformItem = _repository.GetProductById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(platformItem));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task <ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var productFromModel = _mapper.Map<Product>(productCreateDto);
            _repository.CreateProduct(productFromModel);
            _repository.SaveChanges();

            var productFromReadDto = _mapper.Map<ProductReadDto>(productFromModel);
            
            try 
            {
                await  _productDataClient.SendPlatformToCommand(productFromReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could NOT send the mesg synchronously: {ex.Message}");
                Console.WriteLine(ex.InnerException);
            }
            return CreatedAtRoute(nameof(GetProductById), new {Id = productFromReadDto.Id}, productFromReadDto);

        }
    }
}