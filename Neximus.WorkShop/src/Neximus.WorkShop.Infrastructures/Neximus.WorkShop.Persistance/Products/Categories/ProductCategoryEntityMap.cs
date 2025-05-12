using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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
        
        }
    }
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public string Slug { get; set; }
    }
}
