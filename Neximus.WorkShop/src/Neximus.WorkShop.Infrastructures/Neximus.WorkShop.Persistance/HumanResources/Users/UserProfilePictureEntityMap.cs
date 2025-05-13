using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserProfilePictureEntityMap : IEntityTypeConfiguration<UserProfilePicture>
    {
        //public string ImageId { get; set; }
        //public string ImageExtension { get; set; }

        public void Configure(EntityTypeBuilder<UserProfilePicture> _)
        {
            _.Property(_ => _.ImageId);
            _.Property(_ => _.ImageExtension);
        }
    }
}
