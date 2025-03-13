namespace SoFetchGrooming.Models
{
    /// <summary>
    /// Product Image Model that stores the image URL for a product
    /// </summary>
    public class ProductImage
    {
        // Primary Key for Product Image Table
        public int ProductImageId { get; set; }

        // Image URL for the product
        public required string ImageUrl { get; set; }

        //Foreign Key relationship to Product

        // Product ID for the product image
        public int ProductId { get; set; }

        // Navigation property for related product
        public Product Product { get; set; }
    }
}
