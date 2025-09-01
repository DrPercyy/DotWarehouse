//file: backend/Warehouse.Core/Inventory/Entities/Supplier.cs

namespace Warehouse.Core.Entities
{
    public class Supplier
    {
        public int Id { get; set; } // Unique identifier of the supplier
        public string LegalName { get; set; } // Name of the supplier
        public string ContractName { get; set; } // Name of the contact person at the supplier
        public string Phone { get; set; } // Supplier's phone number
        public string TaxId { get; set; } // Supplier's tax identification number
        public string Email { get; set; } // Supplier's email address
        public string SAddress { get; set; } // Supplier's physical address
        public bool Active { get; set; } // Indicates if the supplier is active or inactive
        public DateTime CreateDate { get; set; } // Date and time when the supplier was created
        public DateTime UpdateDate { get; set; } // Date and time when the supplier was last updated

        // Navigation property
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
    }
}
