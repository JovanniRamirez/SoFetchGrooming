using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        
        public required string OrderStatus { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // Calculate total price of order
        public decimal OrderTotal
        {
            get
            {
                decimal total = 0;
                foreach (OrderItem item in OrderItems)
                {
                    total += (item.Quantity * item.Price);
                }
                return total;
            }
        }

        // Create order from Shopping Cart
        public static Order CreateOrder(ShoppingCart cart)
        {
            Order order = new Order
            {
                UserId = cart.UserId,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };
            foreach (CartItem item in cart.Items)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.ProductPrice
                };
                order.OrderItems.Add(orderItem);
            }
            return order;
        }
    }
}
