namespace Neximus.WorkShop.Domain.HumanResources.Users
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public UserProfilePicture ProfilePicture { get; set; }
    }
}
