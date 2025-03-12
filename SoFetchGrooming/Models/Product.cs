using System.ComponentModel.DataAnnotations;

namespace SoFetchGrooming.Models
{
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string ProductName { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [Required]
        [StringLength(150)]
        public required string ProductDescription { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Product Quantity in stock
        /// </summary>
        [Required]
        public int ProductQuantity { get; set; }

        /// <summary>
        /// Product Image
        /// </summary>
        [Url]
        public required string ProductImage { get; set; }
    }
}
