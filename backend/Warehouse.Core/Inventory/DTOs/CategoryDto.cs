//file: backend/Warehouse.Core/Inventory/DTOs/CategoryDto.cs

namespace Warehouse.Core.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; } // Unique identifier of the category
        public string Name { get; set; } = string.Empty; // Name of the category
        public string Description { get; set; } = string.Empty; // Description of the category
        public DateTime CreateDate { get; set; } // Date and time when the category was created
        public DateTime UpdateDate { get; set; } // Date and time when the category was last updated
    }
}