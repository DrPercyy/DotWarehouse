using Microsoft.AspNetCore.Mvc;
using Warehouse.API.Filters;
using Warehouse.Core.Entities;
using Warehouse.Core.Inventory.Exceptions;
using Warehouse.Core.Inventory.DTOs;
using Warehouse.Core.Inventory.Interfaces.Services;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.API.Controllers.Inventory
{
    [ApiController]
    [Route("inventory/Unit")]
    [ModuleFeature("Inventory")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // GET: inventory/Unit/{id} - Busca uma unidade por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnit(int id)
        {
            var unit = await _unitService.GetByIdAsync(id);
            if (unit == null)
                throw new NotFoundException($"Unidade com ID {id} não encontrada.");

            return Ok(unit);
        }

        // GET: inventory/Units - Lista todas as unidades
        [HttpGet("Units")]
        public async Task<IActionResult> ListUnits()
        {
            var units = await _unitService.GetAllAsync();
            if (units == null || !units.Any())
                throw new NotFoundException("Nenhuma unidade encontrada.");

            return Ok(units);
        }

        // POST: inventory/Unit - Cria uma nova unidade
        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] UnitDto dto)
        {
            if (dto == null)
                throw new ValidationException("Unidade não pode ser nula.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ValidationException("O nome da unidade é obrigatório.");

            var unit = new Unit
            {
                Name = dto.Name,
                Abbreviation = dto.Abbreviation,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            await _unitService.AddAsync(unit);
            return CreatedAtAction(nameof(GetUnit), new { id = unit.Id }, unit);
        }

        // PUT: inventory/Unit/{id} - Atualiza uma unidade por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnit(int id, [FromBody] Unit unit)
        {
            if (unit == null)
                throw new ValidationException("Unidade não pode ser nula.");

            if (id != unit.Id)
                throw new ValidationException("O ID da unidade na URL não corresponde ao ID do corpo.");

            await _unitService.UpdateAsync(unit);
            return NoContent();
        }

        // DELETE: inventory/Unit/{id} - Deleta uma unidade por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitService.DeleteAsync(id);
            return NoContent();
        }
    }
}