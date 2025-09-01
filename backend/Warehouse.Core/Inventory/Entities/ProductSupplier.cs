//file: backend/Warehouse.Core/Inventory/Entities/ProductSupplier.cs

namespace Warehouse.Core.Entities
{
    public class ProductSupplier
    {
        public int Id { get; set; } // Primary Key
        public int ProductId { get; set; } // Foreign Key
        public int SupplierId { get; set; } // Foreign Key
        public decimal CostPrice { get; set; } // Cost price of the product from this supplier
        public DateTime LastSupplyDate { get; set; } // Last supply date
        public DateTime CreateDate { get; set; } // Created date
        public DateTime UpdateDate { get; set; } // Updated date

        // Navigation properties
        public Product Product { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
    }
}
