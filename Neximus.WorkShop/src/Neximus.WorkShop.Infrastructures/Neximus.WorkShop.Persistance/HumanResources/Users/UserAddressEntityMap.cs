using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserAddressEntityMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> _)
        {
            _.ToTable("UserAddresses");

            _.HasKey(_ => _.Id);

            _.Property(_ => _.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.UserId).IsRequired();
            _.Property(_ => _.Address).IsRequired();
            _.Property(_ => _.Country).IsRequired();
            _.Property(_ => _.City).IsRequired();
            _.Property(_ => _.PostalCode).IsRequired();

            _.HasOne(_ => _.User)
                .WithMany(_ => _.UserAddress)
                .HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
