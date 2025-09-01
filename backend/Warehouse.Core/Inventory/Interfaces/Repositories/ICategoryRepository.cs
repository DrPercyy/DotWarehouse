//file: backend/Warehouse.Core/Inventory/Interfaces/Repositories/ICategoryRepository.cs

using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByNameAsync(string name);
}  