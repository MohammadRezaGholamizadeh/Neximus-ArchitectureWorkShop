using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _customer;

        public CustomerRepository(EFDataContext context)
        {
            _customer = context.Customres;
        }

        public void Add(Customer customer)
        {
            _customer.Add(customer);
        }
    }
}
