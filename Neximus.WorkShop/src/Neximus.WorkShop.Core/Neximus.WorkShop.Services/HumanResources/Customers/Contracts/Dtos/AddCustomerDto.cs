using Neximus.WorkShop.Domain.HumanResources.Users;
using System.ComponentModel.DataAnnotations;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos
{
    public class AddCustomerDto
    {
        public AddCustomerDto()
        {
            Addresses = new List<AddCustomerAddressDto>();
            ContactInfo = new AddCustomerContactInformationDto();
            ProfilePicture = new AddCustomerProfilePictureDto();
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public AddCustomerContactInformationDto ContactInfo { get; set; }
        public AddCustomerProfilePictureDto ProfilePicture { get; set; }
        public List<AddCustomerAddressDto> Addresses { get; set; }
    }
}
