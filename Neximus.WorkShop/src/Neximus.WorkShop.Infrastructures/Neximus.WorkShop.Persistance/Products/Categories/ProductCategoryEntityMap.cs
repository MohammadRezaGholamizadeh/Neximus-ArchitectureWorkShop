using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Categories;

namespace Neximus.WorkShop.Persistance.Products.Categories
{
    public class ProductCategoryEntityMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> _)
        {
            _.ToTable("ProductCategory");
            
            _.HasKey(x => x.Id);
            
            _.Property(x => x.Id).ValueGeneratedOnAdd();
            
            _.Property(x=>x.Title).IsRequired().HasMaxLength(200);

            _.Property(x => x.Description).IsRequired().HasMaxLength(2500);

            _.Property(x => x.Slug).IsRequired().HasMaxLength(400);
        }
    }
    
    // public class ProductCategory
    // {
    //     public long Id { get; set; }
    //     public string Title { get; set; }
    //     public string Descripton { get; set; }
    //     public string Slug { get; set; }
    // }
}
