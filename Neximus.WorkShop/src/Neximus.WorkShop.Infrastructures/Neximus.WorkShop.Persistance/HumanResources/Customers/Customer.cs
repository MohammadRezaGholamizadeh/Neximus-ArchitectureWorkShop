using Neximus.WorkShop.Persistance.HumanResources.Users;
using Neximus.WorkShop.Persistence.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class Customer : User
    {
        public User User { get; set; }
        public int OrderNumber { get; set; }
        public string Identifire { get; set; }
    }
}
