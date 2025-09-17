using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Core.Entities;
using Warehouse.Core.Inventory.Exceptions;
using Warehouse.Core.Inventory.Interfaces.Repositories;
using Warehouse.Core.Inventory.Interfaces.Services;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.Infra.Inventory.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IProductRepository _productRepository;

        public MovementService(IMovementRepository movementRepository, IProductRepository productRepository)
        {
            _movementRepository = movementRepository;
            _productRepository = productRepository;
        }

        public async Task<Movement> GetByIdAsync(int id)
        {
            return await _movementRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Movement>> GetAllAsync()
        {
            return await _movementRepository.GetAllAsync();
        }

        public async Task AddAsync(Movement movement, int productId, int quantity, string movementType, string? note)
        {
            if (movementType != "In" && movementType != "Out")
                throw new ValidationException("O tipo de movimento deve ser 'In' ou 'Out'.");

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new NotFoundException($"Produto com ID {productId} não encontrado.");

            if (quantity <= 0)
                throw new ValidationException("A quantidade deve ser maior que zero.");

            if (movementType == "In")
            {
                product.Stock += quantity;
            }
            else
            {
                if (product.Stock < quantity)
                    throw new ValidationException($"Estoque insuficiente para o produto {productId}. Estoque atual: {product.Stock}.");
                product.Stock -= quantity;
            }

            movement.ProductId = productId;
            movement.Quantity = quantity;
            movement.MovementType = movementType;
            movement.Note = note ?? $"Movimento {movementType} para produto {productId}";
            movement.CreateDate = DateTime.UtcNow;
            movement.UpdateDate = DateTime.UtcNow;

            await _productRepository.UpdateAsync(product);
            await _movementRepository.AddAsync(movement);
        }

        public async Task UpdateAsync(Movement movement)
        {
            var existing = await _movementRepository.GetByIdAsync(movement.Id);
            if (existing == null)
                throw new NotFoundException($"Movimento com ID {movement.Id} não encontrado.");

            await _movementRepository.UpdateAsync(movement);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _movementRepository.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException($"Movimento com ID {id} não encontrado.");

            await _movementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Movement>> GetProductMovementsAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new NotFoundException($"Produto com ID {productId} não encontrado.");

            return await _movementRepository.GetProductMovementsAsync(productId);
        }
    }
}