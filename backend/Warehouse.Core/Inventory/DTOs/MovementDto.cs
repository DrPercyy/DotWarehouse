namespace Warehouse.Core.DTOs
{
    public class MovementDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string MovementType { get; set; } = string.Empty; // e.g., "IN" for incoming, "OUT" for outgoing
        public string Note { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }

}