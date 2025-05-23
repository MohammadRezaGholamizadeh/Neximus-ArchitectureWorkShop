using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistance.Products.Products
{

    public class ProdcutImageEntityMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage>_)
        {
            _.ToTable("ProductImages");
            _.HasKey(x=>x.Id);
            _.Property(x => x.Id).IsRequired();
            _.Property(x => x.ProductId).IsRequired();
            _.Property(x=>x.ImageId).IsRequired();
            _.Property(x=>x.ImageExtension).IsRequired();
            _.HasOne(x => x.Product).WithMany(x=>x.Images).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
