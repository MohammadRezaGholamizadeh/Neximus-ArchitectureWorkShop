using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.Carts.Carts;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{

    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> _)
        {
            _.ToTable("User");
            _.HasKey(x => x.Id);
            _.Property(x => x.UserName).IsRequired().HasMaxLength(64);
            _.Property(x => x.FirstName).IsRequired().HasMaxLength(128);
            _.Property(x => x.LastName).IsRequired().HasMaxLength(128);
            _.Property(x => x.Gender).IsRequired();
            _.OwnsOne(x => x.ProfilePicture);
            _.HasMany(x=>x.Carts).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);
        }
    }

}
