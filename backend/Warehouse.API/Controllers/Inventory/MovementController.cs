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
    [Route("inventory/Movement")]
    [ModuleFeature("Inventory")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        // POST: inventory/Movement - Cria um novo movimento
        [HttpPost]
        public async Task<IActionResult> CreateMovement([FromBody] CreateMovementDto dto)
        {
            if (dto == null)
                throw new ValidationException("Movimento não pode ser nulo.");

            var movement = new Movement();
            await _movementService.AddAsync(movement, dto.ProductId, dto.Quantity, dto.MovementType, dto.Note);

            return CreatedAtAction(nameof(GetMovement), new { id = movement.Id }, movement);
        }

        // GET: inventory/Movement/{id} - Busca um movimento por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovement(int id)
        {
            var movement = await _movementService.GetByIdAsync(id);
            if (movement == null)
                throw new NotFoundException($"Movimento com ID {id} não encontrado.");

            return Ok(movement);
        }

        // GET: inventory/Movements - Lista todos os movimentos
        [HttpGet("Movements")]
        public async Task<IActionResult> ListMovements()
        {
            var movements = await _movementService.GetAllAsync();
            if (movements == null || !movements.Any())
                throw new NotFoundException("Nenhum movimento encontrado.");

            return Ok(movements);
        }

        // PUT: inventory/Movement/{id} - Atualiza um movimento por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovement(int id, [FromBody] Movement movement)
        {
            if (movement == null)
                throw new ValidationException("Movimento não pode ser nulo.");

            if (id != movement.Id)
                throw new ValidationException("O ID do movimento na URL não corresponde ao ID do corpo.");

            await _movementService.UpdateAsync(movement);
            return NoContent();
        }

        // DELETE: inventory/Movement/{id} - Deleta um movimento por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovement(int id)
        {
            await _movementService.DeleteAsync(id);
            return NoContent();
        }
    }
}