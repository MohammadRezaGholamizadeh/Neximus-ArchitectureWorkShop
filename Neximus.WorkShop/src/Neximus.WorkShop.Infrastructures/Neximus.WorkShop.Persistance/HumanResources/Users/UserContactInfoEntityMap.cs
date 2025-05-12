using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserContactInfoEntityMap : IEntityTypeConfiguration<UserContactInfo>
    {
        public void Configure(EntityTypeBuilder<UserContactInfo> _)
        {

        }
    }
}
