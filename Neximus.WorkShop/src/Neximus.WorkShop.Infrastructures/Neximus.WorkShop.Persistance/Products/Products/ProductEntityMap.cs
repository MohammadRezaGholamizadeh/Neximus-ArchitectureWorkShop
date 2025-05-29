using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Categories;
using Neximus.WorkShop.Domain.Products.Products;
using Neximus.WorkShop.Persistance.Products.Categories;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Product");
            
            _.HasKey(x => x.Id);
            
            _.Property(x => x.Id).ValueGeneratedOnAdd();
            
            _.Property(x => x.Name).IsRequired().HasMaxLength(300);

            _.Property(x => x.Price).IsRequired();
            
            _.Property(x => x.Stock).IsRequired();
            
            _.Property(x => x.CategoryId).IsRequired();
            
            _.Property(x => x.PaperCount).IsRequired();
            
            _.Property(x => x.AuthorName).IsRequired().HasMaxLength(150);
            
            _.Property(x => x.PublishDate).IsRequired();
            
            _.Property(x => x.ISBN).IsRequired().HasMaxLength(150);
            
            _.Property(x => x.Discount).IsRequired();

            _.HasOne(_ => _.ProductCategory).WithMany(_ => _.Products)
                .HasForeignKey(_ => _.CategoryId);
            
            _.HasMany(_=>_.ProductImages).WithOne(_ => _.Product)
                .HasForeignKey(_ => _.ProductId);
        }
    }
    
    // public class ProductEntityMap
    // {
    //     public long Id { get; set; }
    //     public string Name { get; set; }
    //     public decimal Price { get; set; }
    //     public int Stock { get; set; }
    //     public long CategoryId { get; set; }
    //     public ProductCategory ProductCategory { get; set; }
    //     public int PaperCount { get; set; }
    //     public string AuthorName { get; set; }
    //     public DateTime PublishDate { get; set; }
    //     public string ISBN { get; set; }
    //     public decimal Discount { get; set; }
    // }
}
