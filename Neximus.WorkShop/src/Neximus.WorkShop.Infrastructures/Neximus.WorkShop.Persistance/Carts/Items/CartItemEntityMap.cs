using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Carts;
using Neximus.WorkShop.Domain.Carts.Items;
using Neximus.WorkShop.Persistance.Products.Products;

namespace Neximus.WorkShop.Persistance.Carts.Items
{
    public class CartItemEntityMap : IEntityTypeConfiguration<CartItem>
    {//done
        public void Configure(EntityTypeBuilder<CartItem> _)
        {
            _.ToTable("CartItems");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.CartId).IsRequired();
            _.Property(_ => _.ProductId).IsRequired();
            _.Property(_ => _.Quantity).IsRequired();

            _.HasOne(_ => _.Product).WithMany()
                .HasForeignKey(_ => _.ProductId);

                _.HasOne(_ => _.Cart).WithMany(_ => _.Items)
                    . HasForeignKey(_ => _.CartId);
        }
    }

 
}
