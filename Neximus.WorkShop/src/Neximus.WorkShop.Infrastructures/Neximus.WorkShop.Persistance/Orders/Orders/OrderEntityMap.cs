using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Orders;

namespace Neximus.WorkShop.Persistence.Orders.Orders;

    public class OrderEntityMap:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.CreationDate)
                .IsRequired();
            builder.Property(x => x.PaymentDate)
                .IsRequired();
            builder.Property(x => x.TransactionNumber)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.TotalDiscount)
                .IsRequired();
            builder.Property(x => x.TotalPrice)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

