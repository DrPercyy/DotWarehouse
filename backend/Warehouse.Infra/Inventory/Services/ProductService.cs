using Warehouse.Core.Entities;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.Infra.Inventory.Services;

public class ProductService(IProductRepository _productRepository) : IProductService
{
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id); 
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId)
    {
        throw new NotImplementedException();
    }
}