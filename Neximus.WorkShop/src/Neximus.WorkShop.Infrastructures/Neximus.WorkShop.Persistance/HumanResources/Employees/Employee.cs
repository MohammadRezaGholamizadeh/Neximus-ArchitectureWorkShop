using Neximus.WorkShop.Persistance.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Employees
{
    public class Employee : User
    {
        public User User { get; set; }
        public string PersonnelNumber { get; set; }
        public string EmergencyCode { get; set; }
    }
}
