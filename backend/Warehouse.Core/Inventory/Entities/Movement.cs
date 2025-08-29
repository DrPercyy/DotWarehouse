namespace Warehouse.Core.Entities
{
    public class Movement
    {
        public int Id { get; set; } // Unique identifier of the movement
        public int ProductId { get; set; } // Identifier of the product involved in the movement
        public int Quantity { get; set; } // Quantity of the product moved
        public string MovementType { get; set; } // Type of movement (e.g., "IN" for incoming, "OUT" for outgoing)
        public string Note { get; set; } // Description or reason for the movement
        public DateTime CreateDate { get; set; } // Date and time when the movement record was created
        public DateTime UpdateDate { get; set; } // Date and time when the movement record was last updated

        // Navigation property
        public Product Product { get; set; } = null!;
    }
}
