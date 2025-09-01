//file: backend/Warehouse.API/Controllers/Inventory/ProductController.cs

using Microsoft.AspNetCore.Mvc;
using Warehouse.API.Filters;
using Warehouse.Core.Entities;
using Warehouse.Core.Inventory.Exceptions;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.API.Controllers.Inventory
{
    [ApiController]
    [Route("inventory/[controller]")]
    [ModuleFeature("Inventory")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: inventory/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException($"Produto com ID {id} não encontrado.");

            return Ok(product);
        }

        // GET: inventory/Allproducts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if (products == null || !products.Any())
                throw new NotFoundException("Nenhum produto encontrado.");

            return Ok(products);
        }

        // POST: inventory/product
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            if (product == null)
                throw new ValidationException("Produto não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException("O nome do produto é obrigatório.");

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: inventory/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (product == null)
                throw new ValidationException("Produto não pode ser nulo.");

            if (id != product.Id)
                throw new ValidationException("O ID do produto na URL não corresponde ao ID do corpo.");

            var existing = await _productService.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException($"Produto com ID {id} não encontrado.");

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        // DELETE: inventory/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productService.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException($"Produto com ID {id} não encontrado.");

            await _productService.DeleteAsync(id);
            return NoContent();
        }

        // GET: inventory/product/by-category/{categoryId}
        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            if (products == null || !products.Any())
                throw new NotFoundException($"Nenhum produto encontrado para a categoria {categoryId}.");

            return Ok(products);
        }

        // GET: inventory/product/search?term=xyz
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new ValidationException("O termo de busca não pode ser vazio.");

            var products = await _productService.SearchProductsAsync(term);
            if (products == null || !products.Any())
                throw new NotFoundException($"Nenhum produto encontrado para o termo '{term}'.");

            return Ok(products);
        }

        // GET: inventory/product/{id}/movements
        [HttpGet("{id}/movements")]
        public async Task<IActionResult> GetMovements(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException($"Produto com ID {id} não encontrado.");

            var movements = await _productService.GetProductMovementsAsync(id);
            if (movements == null || !movements.Any())
                throw new NotFoundException($"Nenhum movimento encontrado para o produto {id}.");

            return Ok(movements);
        }
    }
}
