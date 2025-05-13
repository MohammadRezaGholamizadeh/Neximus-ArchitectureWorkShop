using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Persistance.HumanResources.Employees
{
    public class EmployeeEntityMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> _)
        {
            _.Property(_ => _.PersonnelNumber);
            _.Property(_ => _.EmergencyCode);
            _.HasOne(_ => _.User);
        }
    }
}
