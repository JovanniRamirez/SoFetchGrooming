using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}