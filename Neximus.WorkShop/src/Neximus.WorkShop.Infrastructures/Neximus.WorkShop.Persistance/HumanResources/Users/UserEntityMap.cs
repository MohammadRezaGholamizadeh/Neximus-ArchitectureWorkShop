using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistence.HumanResources.Users;

public class UserEntityMap:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    { 
        builder.HasKey(x => x.Id);
        builder.ToTable("Users");
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.RegistrationDate ).IsRequired();
        builder
            .HasMany(x => x.Carts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(x => x.ProfilePicture, _ =>
        {
            _.Property(x => x.ImageId).HasColumnName("ProfilePictureId")
                .HasMaxLength(450);
            _.Property(x => x.ImageExtension).HasColumnName("ProfilePictureExtension")
                .HasMaxLength(10);
        });
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

