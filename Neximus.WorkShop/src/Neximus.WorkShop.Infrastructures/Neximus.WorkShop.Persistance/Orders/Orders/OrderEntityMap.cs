using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Domain.Orders.Orders;
using Neximus.WorkShop.Domain.Products.Products;
using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.Orders.Orders
{

    public class OrderEntityMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> _)
        {
            _.ToTable("Order");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.UserId).IsRequired();
            _.Property(_ => _.CreationDate).IsRequired();
            _.Property(_ => _.PaymentDate).IsRequired();
            _.Property(_ => _.TransactionNumber).IsRequired();
            _.Property(_ => _.TotalPrice).IsRequired();
            _.Property(_ => _.TotalDiscount).IsRequired();
            _.HasOne(a => a.User)
                .WithMany(a => a.Order)
                .HasForeignKey(a => a.UserId);
        }
    }

}
