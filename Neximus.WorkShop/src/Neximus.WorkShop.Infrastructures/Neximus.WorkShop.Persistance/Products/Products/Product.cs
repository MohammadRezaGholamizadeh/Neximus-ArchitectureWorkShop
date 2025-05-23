using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;
using Neximus.WorkShop.Persistance.Products.Categories;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product>_)
        {
            _.ToTable("Product");
            _.HasKey(x => x.Id);
            _.Property(_=>_.Id).ValueGeneratedOnAdd();
            _.Property(x => x.Name).IsRequired().HasMaxLength(75);
            _.Property(x => x.Price).IsRequired();
            _.Property(x => x.ProductCategory).IsRequired();
            _.Property(x => x.Stock).IsRequired();
            _.Property(x => x.PaperCount).IsRequired();
            _.Property(x => x.PublishDate).IsRequired();
            _.Property(x => x.AuthorName).IsRequired();
            _.Property(x => x.ISBN).IsRequired();
            _.Property(x => x.Discount).IsRequired();
        }
    }
}
