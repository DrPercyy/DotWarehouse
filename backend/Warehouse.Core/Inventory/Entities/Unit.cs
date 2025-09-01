//file: backend/Warehouse.Core/Inventory/Entities/Unit.cs

namespace Warehouse.Core.Entities
{
    // Inventory Models/Entities
    public class Unit
    {
        public int Id { get; set; } // Unique identifier of the unit
        public string Name { get; set; } // Name of the unit (e.g., "piece", "kilogram", "liter")
        public string Abbreviation { get; set; } // Abbreviation of the unit (e.g., "pc", "kg", "L")
        public DateTime CreateDate { get; set; } // Date and time when the unit was created
        public DateTime UpdateDate { get; set; } // Date and time when the unit was last updated

        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
