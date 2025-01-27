using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public required List<CartItem> Items { get; set; } = new List<CartItem>();

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
