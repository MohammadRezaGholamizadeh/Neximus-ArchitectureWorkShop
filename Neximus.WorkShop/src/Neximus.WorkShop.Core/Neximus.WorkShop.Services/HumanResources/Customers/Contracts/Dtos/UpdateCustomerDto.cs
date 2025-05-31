using Neximus.WorkShop.Domain.HumanResources.Users;
using System.ComponentModel.DataAnnotations;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos
{
    public class UpdateCustomerDto
    {
        public UpdateCustomerDto()
        {
            ContactInfo = new UpdateCustomerContactInformationDto();
            ProfilePicture = new UpdateCustomerProfilePictureDto();
            Addresses = new UpdateCustomerAddressDto();
        }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public UpdateCustomerContactInformationDto ContactInfo { get; set; }
        public UpdateCustomerProfilePictureDto ProfilePicture { get; set; }
        public UpdateCustomerAddressDto Addresses { get; set; }
    }


}
