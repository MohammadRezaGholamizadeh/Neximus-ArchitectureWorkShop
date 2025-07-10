using Microsoft.EntityFrameworkCore;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.HumanResources.Customers;

namespace Neximus.WorkShop.Persistance.HumanResources.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbSet<Customer> _customers;

    public CustomerRepository(EFDataContext context)
    {
        _customers = context.Customers;
    }

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public async Task<Customer?> FindById(string id)
    {
        return await _customers.FindAsync(id);
    }

    public void Update(Customer customer)
    {
        _customers.Update(customer);
    }
    
    public void Delete(Customer customer)
    {
        _customers.Remove(customer);
    }
}