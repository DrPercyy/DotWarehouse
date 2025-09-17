//file: backend/Warehouse.Core/Inventory/Interfaces/Services/IUnitService

using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Entities;

namespace Warehouse.Core.Inventory.Interfaces.Services
{
    public interface IUnitService
    {
        Task<Unit> GetByIdAsync(int id);
        Task<IEnumerable<Unit>> GetAllAsync();
        Task AddAsync(Unit unit);
        Task UpdateAsync(Unit unit);
        Task DeleteAsync(int id);
    }
}