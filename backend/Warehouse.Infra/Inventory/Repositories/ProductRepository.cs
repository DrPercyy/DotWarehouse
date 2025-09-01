//file: backend/Warehouse.Infra/Inventory/Repositories/ProductRepository.cs

using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;
using Warehouse.Infra.Data;
namespace Warehouse.Infra.Inventory.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WarehouseDbContext _dbContext;

    public ProductRepository(WarehouseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetByIdAsync(int id) 
        => await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id); // sem "?? new()"

    public async Task<IEnumerable<Product>> GetAllAsync() 
        => await _dbContext.Products.ToListAsync(); // lista vazia é OK, controller pode decidir

    public async Task AddAsync(Product entity)
    {
        await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product is not null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId) 
        => await _dbContext.Products
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync(); // sem "?? new List<Product>()"

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        => await _dbContext.Products
            .Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())
                        || x.Description.ToLower().Contains(searchTerm.ToLower()))
            .ToListAsync(); // sem "?? new List<Product>()"

    public async Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId)
        => await _dbContext.Movements
            .Where(x => x.ProductId == productId)
            .ToListAsync(); // sem "?? new List<Movement>()"
}