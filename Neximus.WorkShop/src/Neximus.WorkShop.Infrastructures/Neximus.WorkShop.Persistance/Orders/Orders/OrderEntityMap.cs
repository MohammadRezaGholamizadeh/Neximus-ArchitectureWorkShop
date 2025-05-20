using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Orders;
<<<<<<< HEAD
using Neximus.WorkShop.Persistance.HumanResources.Users;
=======
>>>>>>> origin/main

namespace Neximus.WorkShop.Persistance.Orders.Orders
{
    public class OrderEntityMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> _)
        {
<<<<<<< HEAD
            _.ToTable("Order");
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

=======
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
}
>>>>>>> origin/main
