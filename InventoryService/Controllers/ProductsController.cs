using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InventoryService.Data;
using InventoryService.Dtos;

namespace InventoryService.Controllers
{
    [Route("api/i/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IInventoryRepo _repository;
        private readonly IMapper _mapper;

        

        public ProductsController(IInventoryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Get Products from InventoryServices");
            var productsItems = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productsItems));

        }
        [HttpPost]
        public ActionResult testInboundConnection()
        {
            Console.WriteLine("--> INBOUND POST # Inventory Service");
            return Ok("Teste Okay from Product Controller"); 
            
        }
    }
}