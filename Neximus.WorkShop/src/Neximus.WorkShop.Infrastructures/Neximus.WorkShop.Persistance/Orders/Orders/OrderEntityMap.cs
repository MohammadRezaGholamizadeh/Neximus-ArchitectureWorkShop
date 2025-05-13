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
            _.HasKey(_ => _.Id);
            _.Property(_ => _.UserId);
            _.Property(_ => _.CreationDate);
            _.Property(_ => _.PaymentDate);
            _.Property(_ => _.TransactionNumber);
            _.Property(_ => _.TotalPrice);
            _.Property(_ => _.TotalDiscount);
            _.HasOne(_ => _.User);
        }
    }
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public User User { get; set; }
    //    public DateTime CreationDate { get; set; }
    //    public DateTime PaymentDate { get; set; }
    //    public string TransactionNumber { get; set; }
    //    public decimal TotalPrice { get; set; }
    //    public decimal TotalDiscount { get; set; }
}

