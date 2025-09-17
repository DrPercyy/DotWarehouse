namespace Warehouse.Core.Inventory.DTOs
{
    public class CreateMovementDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string MovementType { get; set; } // "In" ou "Out"
        public string? Note { get; set; }
    }
}