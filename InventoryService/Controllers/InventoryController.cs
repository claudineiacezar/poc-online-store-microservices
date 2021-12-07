using AutoMapper;
using InventoryService.Data;
using InventoryService.Dtos;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/i/products/{productId}/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepo _repository;
         private readonly IMapper _mapper;

        public InventoryController(IInventoryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        [HttpGet] 
        public ActionResult<IEnumerable<InventoryReadDto>> GetInventoryForProduct(int productId)
        {
            Console.WriteLine($"--> Hit GetInventoryFromProduct: {productId}");
            if(!_repository.ProductExist(productId))
            {
                return NotFound();
            }
            var inventory = _repository.GetInventoryForProduct(productId);
            return Ok(value: _mapper.Map<IEnumerable<InventoryReadDto>>(inventory));
        }
        [HttpGet("{inventoryId}", Name = "GetInventory")]
        public ActionResult<InventoryReadDto> GetInventory(int productId, int inventoryId)
        {
            Console.WriteLine($"--> Hit GetInventory: {productId}/{inventoryId}");
            if(!_repository.ProductExist(productId))
            {
                return NotFound();
            }
            var inventory = _repository.GetInventory(productId, inventoryId);
            if(inventory == null)
            {
                return NotFound();

            }
            return Ok(_mapper.Map<InventoryReadDto>(inventory));

        }
        [HttpPost]
        public ActionResult<InventoryReadDto> CreateInventoryForProduct(int productId, InventoryCreateDto inventoryCreateDto)
        {
            Console.WriteLine($"--> Hit CreateInventoryForProduct: {productId}");
            if(!_repository.ProductExist(productId))
            {
                return NotFound();
            }
            var inventory = _mapper.Map<Inventory>(inventoryCreateDto);
            _repository.createInventory(productId, inventory);
            _repository.SaveChanges();
            var inventoryReadDto = _mapper.Map<InventoryReadDto>(inventory);
            return CreatedAtRoute(nameof(GetInventory),
                new {productId = productId, inventoryId = inventoryReadDto.Id},
                inventoryReadDto);
            
        }



    }
}