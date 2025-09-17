using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;
using Warehouse.Core.Inventory.Interfaces.Repositories;
using Warehouse.Infra.Data;

namespace Warehouse.Infra.Inventory.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly WarehouseDbContext _context;

        public MovementRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<Movement> GetByIdAsync(int id)
        {
            return await _context.Movements.FindAsync(id);
        }

        public async Task<IEnumerable<Movement>> GetAllAsync()
        {
            return await _context.Movements.ToListAsync();
        }

        public async Task AddAsync(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movement movement)
        {
            _context.Movements.Update(movement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movement = await _context.Movements.FindAsync(id);
            if (movement != null)
            {
                _context.Movements.Remove(movement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId)
        {
            return await _context.Movements
                .Where(m => m.ProductId == productId)
                .ToListAsync();
        }
    }
}