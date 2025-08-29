using Warehouse.Core.Interfaces;
using Warehouse.Core.Entities;

public interface IProductSuplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier?> GetByLegalNameAsync(string legalName);
    Task<IEnumerable<ProductSupplier>> GetProductsBySupplierIdAsync(int supplierId);
    Task<IEnumerable<Supplier>> GetActiveSuppliersAsync();
}