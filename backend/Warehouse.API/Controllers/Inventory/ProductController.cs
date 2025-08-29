using Microsoft.AspNetCore.Mvc;
using Warehouse.API.Filters;

namespace Warehouse.API.Controllers.Inventory
{
    [ApiController]
    [Route("inventory/[controller]")]
    [ModuleFeature("Inventory")] // <- aqui passa o nome da feature
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { "Produto 1", "Labubu 2" });
        }
    }
}