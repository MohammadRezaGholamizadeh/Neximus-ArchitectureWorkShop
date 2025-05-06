using Neximus.WorkShop.Domain.Products.Categories;

namespace Neximus.WorkShop.Domain.Products.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int PaperCount { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public decimal Discount { get; set; }
    }
}
