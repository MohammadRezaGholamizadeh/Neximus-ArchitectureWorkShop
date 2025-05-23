using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Categories;

namespace Neximus.WorkShop.Persistance.Products.Categories
{

    public class ProductCategoryMapEntity : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory>_)
        {
            _.ToTable("ProductCategory");
            _.HasKey(x => x.Id);
            _.Property(x => x.Id).ValueGeneratedOnAdd();
            _.Property(x=>x.Title).IsRequired().HasMaxLength(68);
            _.Property(x=>x.Descripton).IsRequired().HasMaxLength(250);
            _.Property(x=>x.Slug).IsRequired().HasMaxLength(65);
        }
    }
}
