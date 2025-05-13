using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Carts;
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
            _.Property(x => x.CartId);
            _.HasOne(x => x.Cart);
            _.Property(x => x.ProductId);
            _.HasOne(x => x.Product);
            _.Property(x => x.Quantity);
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
}
