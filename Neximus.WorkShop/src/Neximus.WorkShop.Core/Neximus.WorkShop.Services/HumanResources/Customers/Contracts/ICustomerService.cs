using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos;
using Neximus.WorkShop.Services.Infrastructures.Contracts;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts
{
    public interface ICustomerService : IService
    {
        Task<string> Add(AddCustomerDto dto);
    }
}
