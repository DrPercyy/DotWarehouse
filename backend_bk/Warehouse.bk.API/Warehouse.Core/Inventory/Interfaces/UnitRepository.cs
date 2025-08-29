using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;


public interface IUnitRepository : IRepository<Unit>
{
    Task<Unit?> GetByNameAsync(string name);
}