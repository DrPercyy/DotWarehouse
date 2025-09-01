//file: backend/Warehouse.Core/Inventory/Interfaces/Services/IBaseServices.cs

namespace Warehouse.Infra.Inventory.Services.Interfaces;

public interface IBaseServices<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}