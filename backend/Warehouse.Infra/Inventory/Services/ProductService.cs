using Warehouse.Core.Entities;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.Infra.Inventory.Services;

public class ProductService(IProductRepository _productRepository) : IProductService
{
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id); 
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task AddAsync(Product entity)
    {
        await _productRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(Product entity)
    {
        await _productRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return await _productRepository.GetProductsByCategoryIdAsync(categoryId);
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        return await _productRepository.SearchProductsAsync(searchTerm);
    }

    public async Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId)
    {
        return await _productRepository.GetProductMovementsAsync(productId);
    }
}