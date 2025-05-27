using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerQuery : ICustomerQuery
    {
        private readonly EFDataContext _context;

        public CustomerQuery(EFDataContext context)
        {
            _context = context;
        }


    }
}
