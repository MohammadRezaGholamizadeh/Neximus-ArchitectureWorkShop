using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Items;

namespace Neximus.WorkShop.Persistence.Carts.Items;

public class CartItemEntityMap:IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.ToTable("CartItems");
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId);
         

    }
}

//public class CartItem
//{
//    public long Id { get; set; }
//    public long CartId { get; set; }
//    public Cart Cart { get; set; }
//    public long ProductId { get; set; }
//    public Product Product { get; set; }
//    public int Quantity { get; set; }
//}

