using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;
using Warehouse.Infra.Data;
namespace Warehouse.Infra.Inventory.Repositories;


public class ProductRepository(WarehouseDbContext  _dbContext) : IProductRepository
{
    public async Task<Product> GetByIdAsync(int id) => await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id)??new ();
    

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