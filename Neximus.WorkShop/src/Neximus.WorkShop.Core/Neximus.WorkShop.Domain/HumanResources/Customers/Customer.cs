using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Domain.HumanResources.Customers;

public class Customer : User
{
    public User User { get; set; }
    public int OrderNumber { get; set; }
    public string Identifire { get; set; }
}
