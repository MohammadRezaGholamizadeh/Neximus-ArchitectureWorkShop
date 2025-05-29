using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Domain.Products.Categories
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
