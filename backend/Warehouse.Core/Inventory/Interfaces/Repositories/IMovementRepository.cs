using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Core.Inventory.Interfaces.Repositories
{
    public interface IMovementRepository
    {
        Task<Movement> GetByIdAsync(int id);
        Task<IEnumerable<Movement>> GetAllAsync();
        Task AddAsync(Movement movement);
        Task UpdateAsync(Movement movement);
        Task DeleteAsync(int id);
        Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId);
    }
}