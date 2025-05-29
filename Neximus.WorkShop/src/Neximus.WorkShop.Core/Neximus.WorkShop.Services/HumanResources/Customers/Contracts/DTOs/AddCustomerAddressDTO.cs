using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs
{
    public record AddCustomerAddressDTO
        (
        string address,
        string country,
        string city,
        string postalCode
        );
}
