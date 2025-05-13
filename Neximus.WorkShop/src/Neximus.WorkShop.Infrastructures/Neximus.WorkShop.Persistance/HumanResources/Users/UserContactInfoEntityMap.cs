using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserContactInfoEntityMap : IEntityTypeConfiguration<UserContactInfo>
    {
        public void Configure(EntityTypeBuilder<UserContactInfo> _)
        {
            _.Property(_ => _.Email);
            _.Property(_ => _.CountryCallingCode);
            _.Property(_ => _.MobileNumber);
        }
    }
    //{
    //    public string MobileNumber { get; set; }
    //    public string CountryCallingCode { get; set; }
    //    public string Email { get; set; }
}
}
