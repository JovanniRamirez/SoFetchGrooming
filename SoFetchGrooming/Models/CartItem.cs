using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        
        [Required]
        public int CartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public virtual required Product Product { get; set; }

        [Required]
        public virtual required ShoppingCart Cart { get; set; }
    }
}