using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    /// <summary>
    /// CartItem class to represent the items in the shopping cart
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// CartItem ID is the ID of the item in the cart
        /// </summary>
        [Key]
        public int CartItemId { get; set; }

        /// <summary>
        /// Cart ID is the ID of the cart that the item is in
        /// </summary>
        [Required]
        [StringLength(50)]
        public int CartId { get; set; }

        /// <summary>
        /// Product ID is the ID of the product in the cart
        /// </summary>
        [Required]
        [StringLength(50)]
        public int ProductId { get; set; }

        /// <summary>
        /// Quantity is the quantity of the product in the cart
        /// </summary>
        [Required]
        [StringLength(50)]
        public int Quantity { get; set; }

        /// <summary>
        /// Product is the product in the cart item ForeignKey
        /// </summary>
        [Required]
        [StringLength(50)]
        public virtual required Product Product { get; set; }

        /// <summary>
        /// Cart is the cart in the cart item ForeignKey
        /// </summary>
        [Required]
        public virtual required ShoppingCart Cart { get; set; }
    }
}