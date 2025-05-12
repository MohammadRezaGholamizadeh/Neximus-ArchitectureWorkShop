using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductImageEntityMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> _)
        {
            _.ToTable("ProductImages");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.ProductId).IsRequired();
            _.Property(_ => _.ImageId).IsRequired();
            _.Property(_ => _.ImageExtension).IsRequired();

       
        }
    }


}
