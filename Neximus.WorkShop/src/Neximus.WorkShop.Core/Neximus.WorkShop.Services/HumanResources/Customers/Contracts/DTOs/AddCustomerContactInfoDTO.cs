using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs
{
    public class AddCustomerContactInfoDTO
    {
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string CountyCallingCode { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
