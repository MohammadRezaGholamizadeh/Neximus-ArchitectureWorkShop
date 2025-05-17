using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Domain.Orders.Orders;

namespace Neximus.WorkShop.Persistance.Orders.Orders;

public class OrderEntityMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> _)
    {
        _.ToTable("Orders");

        _.HasKey(_ => _.Id);

        _.Property(_ => _.Id).ValueGeneratedOnAdd();

        _.Property(_ => _.UserId).IsRequired();
        _.Property(_ => _.CreationDate).IsRequired();
        _.Property(_ => _.PaymentDate).IsRequired();
        _.Property(_ => _.TransactionNumber).IsRequired();
        _.Property(_ => _.TotalPrice).IsRequired();
        _.Property(_ => _.TotalDiscount).IsRequired();

        _.HasOne(_ => _.User).WithMany()
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}