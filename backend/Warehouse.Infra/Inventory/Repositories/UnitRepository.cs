// file: backend/Warehouse.Infra/Inventory/Repositories/UnitRepository.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;
using Warehouse.Infra.Data;

namespace Warehouse.Infra.Inventory.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly WarehouseDbContext _context;

        public UnitRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> GetByIdAsync(int id)
        {
            return await _context.Units.FindAsync(id);
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Unit unit)
        {
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit != null)
            {
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Unit?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}