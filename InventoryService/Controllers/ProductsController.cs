using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/i/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            
        }
        [HttpPost]
        public ActionResult testInboundConnection()
        {
            Console.WriteLine("--> INBOUND POST # Inventory Service");
            return Ok("Teste Okay from Product Controller"); 
            
        }
    }
}