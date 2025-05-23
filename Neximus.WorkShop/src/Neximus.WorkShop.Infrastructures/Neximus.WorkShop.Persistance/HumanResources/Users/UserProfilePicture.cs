using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users;


public class UserProfilePiCtureEntityMap : IEntityTypeConfiguration<UserProfilePicture>
{
    public void Configure(EntityTypeBuilder<UserProfilePicture> _)
    {
        _.ToTable("UserProfilePicture");
        _.HasKey(x=>x.ImageId);
        _.Property(x=>x.ImageExtension).IsRequired();
    }
}
//public class UserProfilePicture
//{
//    public string ImageId { get; set; }
//    public string ImageExtension { get; set; }
//}
