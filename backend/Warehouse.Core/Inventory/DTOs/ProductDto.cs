//file: backend/Warehouse.Core/Inventory/DTOs/ProductDto.cs

namespace Warehouse.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}