using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Customers;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerEntityMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> _)
        {
            _.ToTable("Customers");

            _.Property(_ => _.OrderNumber).IsRequired();
            _.Property(_ => _.Identifire).IsRequired();

            _.HasOne(_ => _.User).WithOne()
                .HasForeignKey<Customer>(_ => _.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
