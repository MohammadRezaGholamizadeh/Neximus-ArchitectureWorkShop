using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Items;
using Neximus.WorkShop.Persistance.Orders.Orders;
using Neximus.WorkShop.Persistance.Products.Products;

namespace Neximus.WorkShop.Persistance.Orders.Items
{

    public class OrderItemEntityMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem>_)
        {
            _.ToTable("OrderItem");
            _.HasKey(x => x.Id);
            _.Property(x => x.OrderId).IsRequired();
            _.Property(x => x.ProductId).IsRequired();
            _.Property(x => x.Quantity).IsRequired();
            _.Property(x => x.PricePerProduct).IsRequired();
            _.Property(x => x.TotalPrice).IsRequired();
            _.Property(x => x.TotalDiscount).IsRequired();

            _.HasOne(x =>x.Product).WithMany()
                .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
            _.HasOne(x=>x.Order).WithMany(x=>x.items).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
