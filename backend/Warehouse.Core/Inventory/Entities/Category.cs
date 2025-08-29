namespace Warehouse.Core.Entities
{
    // Inventory Models/Entities
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
