using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Persistance.Products.Products
{
   public class ProductImageEntityMap : IEntityTypeConfiguration<ProductImage>
    {
    //    //public long Id { get; set; }
    //    //public long ProductId { get; set; }
    //    //public Product Product { get; set; }
    //    //public string ImageId { get; set; }
    //    //public string ImageExtension { get; set; }
        public void Configure(EntityTypeBuilder<ProductImage> _)
        {
            _.HasKey(x=>x.Id);
            _.Property(_ => _.ProductId);
            _.HasOne(_=>_.Product);
            _.Property(_ => _.ImageId);
            _.Property(_ => _.ImageExtension);


        }
    }
}
