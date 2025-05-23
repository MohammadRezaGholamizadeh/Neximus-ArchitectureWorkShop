using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Employees;
using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Employees
{
    public class EmployeeEntityMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee>_)
        {
            _.ToTable("Employee");
            _.Property(x=>x.PersonnelNumber).IsRequired();
            _.Property(x=>x.EmergencyCode).IsRequired();
            _.HasIndex(x => x.PersonnelNumber).IsUnique();

        }
    }
}
