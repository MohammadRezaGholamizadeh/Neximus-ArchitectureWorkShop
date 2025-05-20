using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Product");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.Name).IsRequired();
            _.Property(_ => _.Price).IsRequired();
            _.Property(_ => _.Stock).IsRequired();
            _.Property(_ => _.CategoryId).IsRequired();
            _.Property(_ => _.PaperCount).IsRequired();
            _.Property(_ => _.AuthorName).IsRequired();
            _.Property(_ => _.PublishDate).IsRequired();
            _.Property(_ => _.ISBN).IsRequired();
            _.Property(_ => _.Discount).IsRequired();
        }
    }
}
