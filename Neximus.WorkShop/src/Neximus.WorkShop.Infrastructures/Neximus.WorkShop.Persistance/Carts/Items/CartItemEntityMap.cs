using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Items;

namespace Neximus.WorkShop.Persistence.Carts.Items;

public class CartItemEntityMap:IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);

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

