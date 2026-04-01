using Core.Concretes.Entities;

namespace Core.Concretes.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductImage { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountValue { get; set; }
        public int Quantity { get; set; }
    }
}
