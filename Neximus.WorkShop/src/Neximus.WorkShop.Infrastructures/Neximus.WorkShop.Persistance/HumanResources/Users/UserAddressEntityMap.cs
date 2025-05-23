using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{

    public class UserAddressEntityMap : IEntityTypeConfiguration<UserAddress>
    {

        public void Configure(EntityTypeBuilder<UserAddress> _)
        {
            _.ToTable("UserAddress");
            _.HasKey(x => x.Id);
            _.Property(x => x.Id).ValueGeneratedOnAdd();
            _.Property(x => x.UserId).IsRequired();
            _.Property(x => x.Address).IsRequired();
            _.Property(x => x.Country).IsRequired();
            _.Property(x => x.City).IsRequired();
            _.Property(x => x.PostalCode).IsRequired();
            _.HasOne(x => x.User).WithMany(x => x.UserAddresses).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}