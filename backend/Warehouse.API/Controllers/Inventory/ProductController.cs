using Microsoft.AspNetCore.Mvc;
using Warehouse.API.Filters;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.API.Controllers.Inventory
{
    [ApiController]
    [Route("inventory/[controller]")]
    [ModuleFeature("Inventory")] // <- aqui passa o nome da feature
    public class ProductController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult >  GetById(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }
    }
}