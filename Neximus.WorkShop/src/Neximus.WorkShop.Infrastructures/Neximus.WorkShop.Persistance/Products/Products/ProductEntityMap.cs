using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;
using Neximus.WorkShop.Persistance.Products.Categories;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
    //    public long Id { get; set; }
    //    public string Name { get; set; }
    //    public decimal Price { get; set; }
    //    public int Stock { get; set; }
    //    public long CategoryId { get; set; }
    //    public ProductCategory ProductCategory { get; set; }
    //    public int PaperCount { get; set; }
    //    public string AuthorName { get; set; }
    //    public DateTime PublishDate { get; set; }
    //    public string ISBN { get; set; }
    //    public decimal Discount { get; set; }

        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Name);
            _.Property(_ => _.Price);
            _.Property(_ => _.Stock);
            _.Property(_ => _.CategoryId);
            _.HasOne(o => o.ProductCategory);
            _.Property(_ => _.PaperCount);
            _.Property(_ => _.AuthorName);
            _.Property(_ => _.PublishDate);
            _.Property(_ => _.ISBN);
            _.Property(_ => _.Discount);
            
        }
    }
}
