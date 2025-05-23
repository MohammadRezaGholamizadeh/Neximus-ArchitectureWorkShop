using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Categories;

namespace Neximus.WorkShop.Persistence.Products.Categories;



public class ProductCategoryEntityMap:IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategory");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Slug).IsRequired();

    }

}

