using Warehouse.Core.Entities;
using Warehouse.Core.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetByNameAsync(string name);
}  