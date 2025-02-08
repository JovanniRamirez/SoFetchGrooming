using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// OrderItem class to represent the items in the order
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// OrderItem ID is the ID of the item in the order
        /// </summary>
        [Key]
        public int OrderItemId { get; set; }

        /// <summary>
        /// Order ID is the ID of the order that the item is in
        /// </summary>
        [Required]
        public int OrderId { get; set; }

        /// <summary>
        /// Product ID is the ID of the product in the order item
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Quantity is the quantity of the product in the order item
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Price is the price of the product in the order item when it was purchased
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Navigation properties for foreign keys
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}