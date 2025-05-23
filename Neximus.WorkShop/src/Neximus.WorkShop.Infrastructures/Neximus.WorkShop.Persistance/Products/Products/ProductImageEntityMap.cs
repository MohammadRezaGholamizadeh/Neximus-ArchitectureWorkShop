using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistence.Products.Products;

public class ProductImageEntityMap:IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages");
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.ProductId)
            .IsRequired();
        builder.Property(x=>x.ImageId)
            .IsRequired();
        builder.Property(x => x.ImageExtension)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductImages)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

