//file: backend/Warehouse.Core/Inventory/DTOs/UnitDto.cs

namespace Warehouse.Core.DTOs
{
    public class UnitDto
    {
        public int Id { get; set; } // Unique identifier of the unit
        public string Name { get; set; } = string.Empty; // Name of the unit (e.g., piece, kilogram, liter)
        public string Abbreviation { get; set; } = string.Empty; // Abbreviation of the unit (e.g., pcs, kg, l)
        public DateTime CreateDate { get; set; } // Date and time when the unit was created
        public DateTime UpdateDate { get; set; } // Date and time when the unit was last updated
    }
}