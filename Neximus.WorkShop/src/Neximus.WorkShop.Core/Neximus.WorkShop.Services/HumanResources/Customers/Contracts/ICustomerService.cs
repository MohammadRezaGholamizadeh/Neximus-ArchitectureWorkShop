using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;
using Neximus.WorkShop.Services.Infrastructures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts
{
    public interface ICustomerService : IService
    {
        Task<string> Add(AddCustomerDTO dto);
    }
}
