using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;
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
            
            _.Property(x => x.Id).ValueGeneratedOnAdd();
            
            _.Property(x => x.UserId).IsRequired();
            
            _.Property(x => x.CreationDate).IsRequired();
            
            _.Property(x => x.PaymentDate).IsRequired();
            
            _.Property(x => x.TransactionNumber).IsRequired().HasMaxLength(350);
            
            _.Property(x => x.TotalPrice).IsRequired();
            
            _.Property(x => x.TotalDiscount).IsRequired();
            
            _.HasOne(_=>_.User).WithMany(_=>_.Orders)
                .HasForeignKey(_=>_.UserId);
        }
    }}
// public class OrderEntityMap
    // {
    //     public long Id { get; set; }
    //     public string UserId { get; set; }
    //     public User User { get; set; }
    //     public DateTime CreationDate { get; set; }
    //     public DateTime PaymentDate { get; set; }
    //     public string TransactionNumber { get; set; }
    //     public decimal TotalPrice { get; set; }
    //     public decimal TotalDiscount { get; set; }
    // }

