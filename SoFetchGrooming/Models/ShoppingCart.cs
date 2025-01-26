using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public required List<CartItem> Items { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal CartTotal { get; set; }
    }
}
