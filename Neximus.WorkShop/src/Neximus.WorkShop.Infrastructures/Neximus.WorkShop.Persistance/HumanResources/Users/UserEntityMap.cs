using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
<<<<<<< HEAD
using Neximus.WorkShop.Domain.Carts.Carts;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.Carts.Carts;
=======
using Neximus.WorkShop.Domain.HumanResources.Users;
>>>>>>> origin/main

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> _)
        {
<<<<<<< HEAD
            _.HasKey(_ => _.Id);
            _.Property(_ => _.IsActive).HasDefaultValue(true);
            _.Property(_ => _.FirstName);
            _.Property(_ => _.LastName);
            _.Property(_ => _.UserName);
            _.Property(_ => _.CreationDate);
            _.Property(_ => _.Gender);
            
            _.OwnsOne(x => x.ProfilePicture, x => 
            {
                x.Property(xx => xx.ImageId).HasColumnName("ImageId");
                x.Property(xx => xx.ImageExtension).HasColumnName("ImageExtension");
            });
            _.HasMany(_ => _.Carts).WithOne(_=>_.User);
            
        }
    }

    //public class User
    //{
    //    public User()
    //    {
    //        Carts = new HashSet<Cart>();
    //    }
    //    public string Id { get; set; }
    //    public string UserName { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime CreationDate { get; set; }
    //    public Gender Gender { get; set; }
    //    public DateTime RegistrationDate { get; set; }
    //    public UserProfilePicture ProfilePicture { get; set; }
    //    public HashSet<Cart> Carts { get; set; }
    //}
=======
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
>>>>>>> origin/main
}
