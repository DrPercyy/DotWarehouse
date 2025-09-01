//file: backend/Warehouse.Core/Inventory/Interfaces/Repositories/ISupplierRepository.cs

using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier> GetByLegalNameAsync(string legalName);
}