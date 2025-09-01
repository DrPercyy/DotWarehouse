//file: backend/Warehouse.Core/Inventory/Interfaces/Repositories/UnitRepository.cs

using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;


public interface IUnitRepository : IBaseRepository<Unit>
{
    Task<Unit?> GetByNameAsync(string name);
}