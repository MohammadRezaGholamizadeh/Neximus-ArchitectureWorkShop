using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Carts;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.Carts.Carts;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> _)
        {
            _.ToTable("Users");

            _.HasKey(x => x.Id);

            _.Property(x => x.Id).ValueGeneratedOnAdd().HasMaxLength(450);

            _.Property(x => x.UserName).IsRequired().HasMaxLength(300);

            _.Property(x => x.FirstName).IsRequired().HasMaxLength(300);

            _.Property(x => x.LastName).IsRequired().HasMaxLength(300);

            _.Property(x => x.IsActive).IsRequired().HasDefaultValue(false);

            _.Property(x => x.CreationDate).IsRequired();

            _.Property(x => x.Gender).IsRequired();

            _.Property(x => x.RegistrationDate).IsRequired();


            _.HasMany(_ => _.Carts).WithOne(_ => _.User).HasForeignKey(_ => _.UserId);

            _.OwnsOne(_ => _.ProfilePicture, _ =>
            {
                _.Property(_ => _.ImageExtension)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasColumnName("ImageExtension");

                _.Property(_ => _.ImageId).IsRequired().HasMaxLength(100)
                    .HasColumnName("ImageId");
            });

            _.OwnsOne(_ => _.ContactInfo, _ =>
            {
                _.Property(_ => _.Email)
                    .HasMaxLength(150)
                    .IsRequired()
                    .HasColumnName("Email");

                _.Property(_ => _.MobileNumber)
                    .HasMaxLength(11)
                    .IsRequired()
                    .HasColumnName("MobileNumber");

                _.Property(_ => _.CountryCallingCode)
                    .HasMaxLength(5)
                    .IsRequired()
                    .HasColumnName("CountryCallingCode");
            });
        }
    }
}