using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Items;
using Neximus.WorkShop.Persistance.Products.Products;

namespace Neximus.WorkShop.Persistance.Carts.Items
{
    public class CartItemEntityMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> _)
        {
            _.ToTable("CartItems");
            _.HasKey(x => x.Id);
            _.Property(x => x.Id).ValueGeneratedOnAdd();
            _.Property(x => x.CartId).IsRequired();
            _.Property(x => x.ProductId).IsRequired();
            _.Property(x=>x.Quantity).IsRequired();
            _.HasOne(x=>x.Cart).WithMany().HasForeignKey(x=>x.CartId).OnDelete(DeleteBehavior.Cascade);
            _.HasOne(x => x.Cart).WithMany().HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
