using System.ComponentModel.DataAnnotations;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;

public class UpdateCustomerDTO
{
    public UpdateCustomerDTO()
    {
        ContactInfo = new UpdateCustomerContactInformationDTO();
        ProfilePicture = new UpdateCustomerProfilePictureDTO();
        Addresses = new UpdateCustomerAddressDTO();
    }

    [Required] public string UserName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public Gender Gender { get; set; }
    public UpdateCustomerContactInformationDTO ContactInfo { get; set; }
    public UpdateCustomerProfilePictureDTO ProfilePicture { get; set; }
    public UpdateCustomerAddressDTO Addresses { get; set; }
}
