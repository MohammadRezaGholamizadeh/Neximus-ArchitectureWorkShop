using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductImageEntityMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> _)
        {
            _.ToTable("ProductImages");

            _.HasKey(x => x.Id);

            _.Property(x => x.Id).ValueGeneratedOnAdd();

            _.Property(x => x.ProductId).IsRequired();

            _.Property(x => x.ImageId).HasMaxLength(450).IsRequired();

            _.Property(x => x.ImageExtension).HasMaxLength(10).IsRequired();
        }
    }

    // public long Id { get; set; }
    // public long ProductId { get; set; }
    // public Product Producttb { get; set; }
    // public string ImageId { get; set; }
    // public string ImageExtension { get; set; 
}