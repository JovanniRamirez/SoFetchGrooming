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
        [Display(Name ="Product Name")]
        [StringLength(50)]
        public required string ProductName { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [Required]
        [Display(Name ="Product Description")]
        [StringLength(200)]
        public required string ProductDescription { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        [Required]
        [Display(Name ="Product Price")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Product Quantity in stock
        /// </summary>
        [Required]
        [Display(Name ="Product Quantity")]
        public int ProductQuantity { get; set; }

        [Display(Name ="Product Image")]
        // Navigation property for related images
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
