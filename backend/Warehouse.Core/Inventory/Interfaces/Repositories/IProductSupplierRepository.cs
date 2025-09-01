//file: backend/Warehouse.Core/Inventory/Interfaces/Repositories/IProductSupplierRepository.cs

using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface IProductSuplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier?> GetByLegalNameAsync(string legalName);
    Task<IEnumerable<ProductSupplier>> GetProductsBySupplierIdAsync(int supplierId);
    Task<IEnumerable<Supplier>> GetActiveSuppliersAsync();
}