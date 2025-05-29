using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Employees;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerEntityMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> _)
        {
            _.ToTable("Customer");

            _.Property(_ => _.OrderNumber).IsRequired();

            _.Property(_ => _.Identifire).IsRequired()
                .HasMaxLength(100);

            _.HasOne(_ => _.User).WithOne()
                .HasForeignKey<Customer>(_ => _.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    // public class CustomerEntityMap : User
    // {
    //     public User User { get; set; }
    //     public int OrderNumber { get; set; }
    //     public string Identifire { get; set; }
    //     //TODO: TPT must done
    // }
}