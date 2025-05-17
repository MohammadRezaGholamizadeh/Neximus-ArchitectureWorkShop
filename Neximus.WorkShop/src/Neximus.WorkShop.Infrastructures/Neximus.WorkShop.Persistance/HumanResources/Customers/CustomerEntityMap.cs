using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers;

public class CustomerEntityMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> _)
    {
        _.ToTable("Customers"); 

        _.HasKey(_ => _.Id); 

        _.Property(_ => _.OrderNumber).IsRequired();
        _.Property(_ => _.Identifire).IsRequired();

        _.HasOne(_ => _.User).WithOne()
            .HasForeignKey<Customer>(_ => _.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
