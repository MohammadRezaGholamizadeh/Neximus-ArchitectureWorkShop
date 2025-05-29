using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Employees;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Employees
{
    public class EmployeeEntityMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> _)
        {
            _.ToTable("Employee");
            _.Property(_=>_.PersonnelNumber).IsRequired()
                .HasMaxLength(100);
            
            _.Property(_=>_.EmergencyCode).IsRequired()
                .HasMaxLength(100);

            _.HasOne(_ => _.User).WithOne()
                .HasForeignKey<Employee>(_ => _.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    // public class EmployeeEntityMap : User
    // {
    //     public UserEntityMap UserEntityMap { get; set; }
    //     public string PersonnelNumber { get; set; }
    //     public string EmergencyCode { get; set; }
    //     
    //     //TODO: TPT must done
    // }
}
