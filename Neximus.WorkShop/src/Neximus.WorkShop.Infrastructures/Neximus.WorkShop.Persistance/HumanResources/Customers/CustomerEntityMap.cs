using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Customers;

namespace Neximus.WorkShop.Persistence.HumanResources.Customers;


public class CustomerEntityMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.Property(x => x.OrderNumber).IsRequired();
        builder.Property(x => x.Identifier).IsRequired();
        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Customer>(_ => _.Id)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

//public class Customer : User
//{
//    public User User { get; set; }
//    public int OrderNumber { get; set; }
//    public string Identifier { get; set; }
//}

