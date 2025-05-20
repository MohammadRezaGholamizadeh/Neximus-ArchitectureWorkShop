using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Employees;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> origin/main

namespace Neximus.WorkShop.Persistance.HumanResources.Employees
{
    public class EmployeeEntityMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> _)
        {
<<<<<<< HEAD
            _.Property(_ => _.PersonnelNumber);
            _.Property(_ => _.EmergencyCode);
            _.HasOne(_ => _.User);
=======
            _.ToTable("Employees");

            _.Property(_ => _.PersonnelNumber).IsRequired();
            _.Property(_ => _.EmergencyCode).IsRequired();

            _.HasOne(_ => _.User).WithOne()
                .HasForeignKey<Employee>(_ => _.Id)
                .OnDelete(DeleteBehavior.Cascade);
>>>>>>> origin/main
        }
    }
}
