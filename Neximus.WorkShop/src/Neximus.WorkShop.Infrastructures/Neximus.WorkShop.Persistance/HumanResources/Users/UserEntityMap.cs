using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> _)
        {
            _.ToTable("Users");
            _.HasKey(_ => _.Id);

            _.Property(_ => _.UserName).IsRequired();
            _.Property(_ => _.FirstName).IsRequired();
            _.Property(_ => _.LastName).IsRequired();
            _.Property(_ => _.IsActive).IsRequired();
            _.Property(_ => _.CreationDate).IsRequired();
            _.Property(_ => _.Gender).IsRequired();
            _.Property(_ => _.RegistrationDate).IsRequired();

            _.HasMany(_ => _.Carts).WithOne(_ => _.User)
                .HasForeignKey(_ => _.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            _.OwnsOne(_ => _.ProfilePicture,
                _ =>
                {
                    _.Property(_ => _.ImageId)
                     .HasColumnName("ProfilePictureId")
                     .HasMaxLength(450);

                    _.Property(_ => _.ImageExtension)
                     .HasColumnName("ProfilePictureExtension")
                     .HasMaxLength(10);
                });

            _.OwnsOne(_ => _.ContactInfo,
                _ =>
                {
                    _.Property(_ => _.MobileNumber)
                     .HasColumnName("MobileNumber")
                     .HasMaxLength(11);

                    _.Property(_ => _.CountryCallingCode)
                     .HasColumnName("CountryCallingCode")
                     .HasMaxLength(4);
                });

            _.HasMany(_ => _.Addresses)
             .WithOne(_ => _.User)
             .HasForeignKey(_ => _.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
