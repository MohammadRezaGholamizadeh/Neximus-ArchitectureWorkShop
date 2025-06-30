using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Services.Infrastructures.Contracts;

namespace Neximus.WorkShop.Services.HumanResources.Customers
{
    public interface ICustomerRepository : IRepository
    {
        void Add(Customer customer);
        void Delete(Customer customer);
        Task<Customer?> FindById(string id);
        void Update(Customer customer);
    }
}
