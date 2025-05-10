namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductImage
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageId { get; set; }
        public string ImageExtension { get; set; }
    }
}
