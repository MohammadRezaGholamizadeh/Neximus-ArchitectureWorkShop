using System.ComponentModel.DataAnnotations;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos
{
    public class UpdateCustomerContactInformationDto
    {
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string CountryCallingCode { get; set; }
        [Required]
        public string Email { get; set; }
    }

}
