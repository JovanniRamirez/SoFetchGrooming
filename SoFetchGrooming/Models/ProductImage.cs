namespace SoFetchGrooming.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public required string ImageUrl { get; set; }

        //Foreign Key relationship to Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
