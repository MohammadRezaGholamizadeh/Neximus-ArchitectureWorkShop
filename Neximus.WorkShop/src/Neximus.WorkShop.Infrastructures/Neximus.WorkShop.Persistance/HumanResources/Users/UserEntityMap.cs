using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Persistence.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users;

public class UserEntityMap:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}

//public class User
//{
//    public string Id { get; set; }
//    public string UserName { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public bool IsActive { get; set; }
//    public DateTime CreationDate { get; set; }
//    public Gender Gender { get; set; }
//    public DateTime RegistrationDate { get; set; }
//    public UserProfilePicture ProfilePicture { get; set; }
//}

