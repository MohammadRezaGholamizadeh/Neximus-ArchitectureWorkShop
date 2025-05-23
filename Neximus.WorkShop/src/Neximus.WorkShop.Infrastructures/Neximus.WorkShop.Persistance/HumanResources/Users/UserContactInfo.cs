using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserContactInfoEntityMap : IEntityTypeConfiguration<UserContactInfo>
    {
        public void Configure(EntityTypeBuilder<UserContactInfo>_)
        {
            _.ToTable("UserContactInfo");
            _.Property(x=>x.MobileNumber).IsRequired().HasMaxLength(128);
            _.Property(x=>x.CountryCallingCode).IsRequired().HasMaxLength(128);
            _.Property(x=>x.Email).IsRequired().HasMaxLength(128);
        }
    }
}
