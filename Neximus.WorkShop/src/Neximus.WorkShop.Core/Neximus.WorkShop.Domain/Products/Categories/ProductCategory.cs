using Neximus.WorkShop.Domain.Orders.Orders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Domain.Products.Categories
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public string Slug { get; set; }
        public HashSet<Product> Product { get; set; }
    }
}
