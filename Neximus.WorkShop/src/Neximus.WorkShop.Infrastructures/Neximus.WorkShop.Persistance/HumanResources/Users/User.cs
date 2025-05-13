using Neximus.WorkShop.Domain.Carts.Carts;
using Neximus.WorkShop.Persistance.Carts.Carts;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public UserProfilePicture ProfilePicture { get; set; }
        public HashSet<Cart> Carts { get; set; }
    }
}
