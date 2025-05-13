using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.Orders.Items;
using Neximus.WorkShop.Domain.Products.Products;
using Neximus.WorkShop.Persistance.Orders.Orders;
using Neximus.WorkShop.Persistance.Products.Products;

namespace Neximus.WorkShop.Persistance.Orders.Items
{
    public class OrderItemEntityMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> _)
        {
            _.ToTable("OrderItems");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.OrderId).IsRequired();
            _.Property(_ => _.ProductId).IsRequired();
            _.Property(_ => _.Quantity).IsRequired();
            _.Property(_ => _.PricePerProduct).IsRequired();
            _.Property(_ => _.TotalPrice).IsRequired();
            _.Property(_ => _.TotalDiscount).IsRequired();


            _.HasOne(a => a.Order)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(a => a.OrderId);

            _.HasOne(a => a.Product)
                .WithMany()
                .HasForeignKey(a => a.OrderId);
        }
    }

}
