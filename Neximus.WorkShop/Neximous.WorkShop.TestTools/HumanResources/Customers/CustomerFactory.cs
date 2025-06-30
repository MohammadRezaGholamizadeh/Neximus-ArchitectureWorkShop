using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;

namespace Neximous.WorkShop.TestTools.HumanResources.Customers;

public static class CustomerFactory
{
    public static AddCustomerDTO Give_Customer_AddDTO(this Generator generator)
    {
        return new AddCustomerDTO()
        {
            UserName = "dummy_UserName",
            FirstName = "dummy_FirstName",
            LastName = "dummy_LastName",
            Gender = Gender.Female,
            ContactInfo = new AddCustomerContactInfoDTO()
            {
                CountyCallingCode = "098",
                Email = "dummy_Email@gmail.com",
                MobileNumber = "0991433556"
            },
            Addresses =
                new List<AddCustomerAddressDTO>()
                {
                    new AddCustomerAddressDTO("address", "country", "city", "postalCode")
                },
            ProfilePicture = new AddCustomerProfilePictureDTO()
            {
                ImageId = Guid.NewGuid().ToString(),
                ImageExtention = "PNG"
            }
        };
    }
}