using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Domain.HumanResources.Employees;

public class Employee : User
{
    public User User { get; set; }
    public string PersonnelNumber { get; set; }
    public string EmergencyCode { get; set; }
}
