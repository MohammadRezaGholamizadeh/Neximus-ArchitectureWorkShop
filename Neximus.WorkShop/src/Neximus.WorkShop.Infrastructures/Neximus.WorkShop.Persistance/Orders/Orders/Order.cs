using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Orders;
using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.Orders.Orders
{
    public class OrderEntityMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> _)
        {
            _.ToTable("Order");
            _.HasKey(x => x.Id);
            _.Property(x=>x.UserId).IsRequired();
            _.Property(x=>x.CreationDate).IsRequired();
            _.Property(x=>x.PaymentDate).IsRequired();
            _.Property(x=>x.TransactionNumber).IsRequired();
            _.Property(x=>x.TotalPrice).IsRequired();
            _.Property(x=>x.TotalDiscount).IsRequired();
            _.HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
