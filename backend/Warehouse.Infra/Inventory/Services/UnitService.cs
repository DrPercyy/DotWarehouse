using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Entities;
using Warehouse.Core.Inventory.Exceptions;
using Warehouse.Core.Inventory.Interfaces.Services;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.Infra.Inventory.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<Unit> GetByIdAsync(int id)
        {
            return await _unitRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _unitRepository.GetAllAsync();
        }

        public async Task AddAsync(Unit unit)
        {
            if (string.IsNullOrWhiteSpace(unit.Name))
                throw new ValidationException("O nome da unidade é obrigatório.");

            await _unitRepository.AddAsync(unit);
        }

        public async Task UpdateAsync(Unit unit)
        {
            if (string.IsNullOrWhiteSpace(unit.Name))
                throw new ValidationException("O nome da unidade é obrigatório.");

            var existing = await _unitRepository.GetByIdAsync(unit.Id);
            if (existing == null)
                throw new NotFoundException($"Unidade com ID {unit.Id} não encontrada.");

            await _unitRepository.UpdateAsync(unit);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _unitRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException($"Unidade com ID {id} não encontrada.");

            await _unitRepository.DeleteAsync(id);
        }
    }
}