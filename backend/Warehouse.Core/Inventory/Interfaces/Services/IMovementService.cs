using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Core.Inventory.Interfaces.Services
{
    public interface IMovementService
    {
        Task<Movement> GetByIdAsync(int id);
        Task<IEnumerable<Movement>> GetAllAsync();
        Task AddAsync(Movement movement, int productId, int quantity, string movementType, string? note);
        Task UpdateAsync(Movement movement);
        Task DeleteAsync(int id);
        Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId);
    }
}