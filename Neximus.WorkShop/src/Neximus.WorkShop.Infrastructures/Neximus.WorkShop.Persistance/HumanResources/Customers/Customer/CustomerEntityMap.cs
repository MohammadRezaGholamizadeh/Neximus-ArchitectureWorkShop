
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Customers;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerEntityMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> _)
        {

            _.Property(_ => _.OrderNumber);
            _.Property(_ => _.Identifire);
            _.HasOne(_ => _.User);
            
        }
    }
}
