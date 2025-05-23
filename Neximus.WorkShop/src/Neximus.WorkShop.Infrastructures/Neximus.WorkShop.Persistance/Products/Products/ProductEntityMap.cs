using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistence.Products.Products;

public class ProductEntityMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(x => x.Price)
            .IsRequired();
        builder.Property(x=>x.Stock)
            .IsRequired();
        builder.Property(x => x.CategoryId)
            .IsRequired();
        builder.Property(x => x.PaperCount)
            .IsRequired();
        builder.Property(x => x.AuthorName)
            .IsRequired()
            .HasMaxLength(25);
        builder.Property(x=>x.PublishDate)
            .IsRequired();
        builder.Property(x => x.ISBN)
            .IsRequired()
            .HasMaxLength(25);
        builder.Property(x => x.Discount).IsRequired();
    }
}

