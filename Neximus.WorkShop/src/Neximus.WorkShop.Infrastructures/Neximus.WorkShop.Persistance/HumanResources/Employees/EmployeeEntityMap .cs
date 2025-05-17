using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Employees;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Employees;

public class EmployeeEntityMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> _)
    {
        _.ToTable("Employees");

        _.Property(_ => _.PersonnelNumber).IsRequired();
        _.Property(_ => _.EmergencyCode).IsRequired();

        _.HasOne(_ => _.User).WithOne()
            .HasForeignKey<Employee>(_ => _.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
