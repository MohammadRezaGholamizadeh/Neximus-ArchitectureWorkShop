using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Domain.Products.Products;
using Neximus.WorkShop.Persistance.Products.Categories;

namespace Neximus.WorkShop.Persistance.Products.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Products");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _. Name).IsRequired();
            _.Property(_ => _. Price).IsRequired();
            _.Property(_ => _. Stock).IsRequired();
            _.Property(_ => _.CategoryId).IsRequired();
            _.Property(_ => _. PaperCount).IsRequired();
            _.Property(_ => _. AuthorName).IsRequired();
            _.Property(_ => _. PublishDate).IsRequired();
            _.Property(_ => _. ISBN).IsRequired();
            _.Property(_ => _. Discount).IsRequired();

            //_.OwnsMany(b => b.ProductImage, _ =>
            //{
            //    _.Property(_ => _.ImageId)
            //        .HasColumnName("ProfilePictureId")
            //        .HasMaxLength(450);

            //    _.Property(_ => _.ImageExtension)
            //        .HasColumnName("ProfilePictureExtension")
            //        .HasMaxLength(10);
            //});
        }
    }


}
