using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface IMovementRepository : IBaseRepository<Movement>
{
    Task<Movement> GetByNameAsync(string name);
}
