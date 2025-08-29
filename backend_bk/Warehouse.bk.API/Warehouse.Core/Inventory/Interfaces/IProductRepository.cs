using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId);
}