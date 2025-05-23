using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerEntityMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> _)
        {
            _.ToTable("Customer");
            _.Property(x => x.OrderNumber).IsRequired();
            _.Property(x => x.Identifire).IsRequired();
        }
    }

 
}
