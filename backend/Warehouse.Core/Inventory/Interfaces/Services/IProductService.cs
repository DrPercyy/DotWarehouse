//file: backend/Warehouse.Core/Inventory/Interfaces/Services/IProductService.cs

using Warehouse.Core.Entities;

namespace Warehouse.Infra.Inventory.Services.Interfaces;


public interface IProductService: IBaseServices<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId);
}