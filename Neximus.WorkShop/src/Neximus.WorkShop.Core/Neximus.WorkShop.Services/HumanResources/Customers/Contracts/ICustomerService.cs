using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;
using Neximus.WorkShop.Services.Infrastructures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neximus.WorkShop.Domain.HumanResources.Customers;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts
{
    public interface ICustomerService : IService
    {
        Task<string> Add(AddCustomerDTO dto);
        Task DeleteById(string id);
        Task Update(string id, UpdateCustomerDTO dto);
    }
}