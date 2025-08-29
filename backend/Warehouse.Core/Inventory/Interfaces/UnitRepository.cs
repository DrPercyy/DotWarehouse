using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;


public interface IUnitRepository : IBaseRepository<Unit>
{
    Task<Unit?> GetByNameAsync(string name);
}