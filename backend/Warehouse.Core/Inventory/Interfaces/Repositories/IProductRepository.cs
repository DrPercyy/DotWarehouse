// file: backend/Warehouse.Core/Inventory/Interfaces/Repositories/IProductRepository.cs

using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId);
}