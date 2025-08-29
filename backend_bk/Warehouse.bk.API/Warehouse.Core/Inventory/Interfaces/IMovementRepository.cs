using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface IMovementRepository : IRepository<Movement>
{
    Task<Movement> GetByNameAsync(string name);
}
