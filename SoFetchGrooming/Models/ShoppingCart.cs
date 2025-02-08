using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// ShoppingCart class to represent the shopping cart in the system
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// CartId is the ID of the shopping cart
        /// </summary>
        [Key]
        public int CartId { get; set; }

        /// <summary>
        /// UserId is the ID of the user who owns the cart
        /// </summary>
        [Required]
        public required string UserId { get; set; }
        
        // ForeignKey
        [ForeignKey("UserId")]
        public virtual required ApplicationUser User { get; set; }

        /// <summary>
        /// Items is the list of items in the cart
        /// </summary>
        [Required]
        public required List<CartItem> Items { get; set; } = new List<CartItem>();

        /// <summary>
        /// ShoppingCartQuantity is the total quantity of items in the cart
        /// </summary>
        public int ShoppingCartQuantity
        {
            get
            {
                int quantity = 0;
                foreach (CartItem item in Items)
                {
                    quantity += item.Quantity;
                }
                return quantity;

            }
        }

        /// <summary>
        /// CartTotal is the total price of the items in the cart
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal CartTotal
        {
            get
            {
                decimal total = 0;
                foreach (CartItem item in Items)
                {
                    total += (item.Quantity * item.Product.ProductPrice);
                }
                return total;
            }
        }
    }
}
