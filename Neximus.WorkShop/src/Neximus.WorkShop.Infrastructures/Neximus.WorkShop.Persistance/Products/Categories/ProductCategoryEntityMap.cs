using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.Products.Categories;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistance.Products.Categories
{

    public class ProductCategoryEntityMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> _)
        {
            _.ToTable("ProductCategories");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Title).IsRequired();
            _.Property(_ => _.Descripton).IsRequired();
            _.Property(_ => _.Slug).IsRequired();

            _.HasMany(a => a.Product)
                .WithOne(a => a.ProductCategory)
                .HasForeignKey(a => a.CategoryId);

        }
    }

}
