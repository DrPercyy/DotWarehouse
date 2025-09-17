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

        // GET: inventory/product/{id} - Busca produto por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                throw new NotFoundException($"Produto com ID {id} não encontrado.");

            return Ok(product);
        }

        // GET: inventory/products - Lista todos os produtos (mudei pra plural pra clareza)
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            if (products == null || !products.Any())
                throw new NotFoundException("Nenhum produto encontrado.");

            return Ok(products);
        }

        // POST: inventory/product - Cria um novo produto
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                throw new ValidationException("Produto não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException("O nome do produto é obrigatório.");

            if (product.UnitId <= 0)
                throw new ValidationException("ID da unidade é obrigatório e deve ser válido.");

            if (product.CategoryId <= 0)
                throw new ValidationException("ID da categoria é obrigatório e deve ser válido.");

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: inventory/product/{id} - Atualiza produto por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
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

        // DELETE: inventory/product/{id} - Deleta produto por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existing = await _productService.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException($"Produto com ID {id} não encontrado.");

            await _productService.DeleteAsync(id);
            return NoContent();
        }

        // GET: inventory/products/by-category/{categoryId} - Busca produtos por categoria
        [HttpGet("products/by-category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            if (products == null || !products.Any())
                throw new NotFoundException($"Nenhum produto encontrado para a categoria {categoryId}.");

            return Ok(products);
        }

        // GET: inventory/products/search?term=xyz - Busca produtos por termo
        [HttpGet("products/search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new ValidationException("O termo de busca não pode ser vazio.");

            var products = await _productService.SearchProductsAsync(term);
            if (products == null || !products.Any())
                throw new NotFoundException($"Nenhum produto encontrado para o termo '{term}'.");

            return Ok(products);
        }

        // GET: inventory/product/{id}/movements - Busca movimentações de um produto
        [HttpGet("{id}/movements")]
        public async Task<IActionResult> GetProductMovements(int id)
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