using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Items;

namespace Neximus.WorkShop.Persistance.Orders.Items
{
    public class EFOrderItemEntityMap : IEntityTypeConfiguration<OrderItem>
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

            _.HasOne(_ => _.Product).WithMany()
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            _.HasOne(_ => _.Order)
                .WithMany(_ => _.Items)
                .HasForeignKey(_ => _.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
