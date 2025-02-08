using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Order class to represent the orders in the system
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID is the ID of the order
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// User ID is the ID of the user who placed the order
        /// </summary>
        [Required]
        public required string UserId { get; set; }

        /// <summary>
        /// User is the user who placed the order ForeignKey
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        /// <summary>
        /// OrderDate is the date the order was placed
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// OrderStatus is the status of the order
        /// </summary>
        [Required]
        public required OrderStatus Status { get; set; }

        /// <summary>
        /// OrderItems is the list of items in the order
        /// </summary>
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
                Status = OrderStatus.Pending
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

/// <summary>
/// OrderStatus enum to represent the status of the order
/// </summary>
public enum OrderStatus
{
    // Pending: The order has been placed but not yet processed
    Pending,

    // Processing: The order is being processed
    Processing,

    // Shipped: The order has been shipped
    Shipped,

    // Delivered: The order has been delivered
    Delivered,

    // Cancelled: The order has been cancelled
    Cancelled,

    // Returned: The order has been returned
    Returned
}