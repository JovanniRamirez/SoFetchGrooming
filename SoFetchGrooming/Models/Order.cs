using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        
        public required string OrderStatus { get; set; }

        // Navigation property
        public virtual required User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
