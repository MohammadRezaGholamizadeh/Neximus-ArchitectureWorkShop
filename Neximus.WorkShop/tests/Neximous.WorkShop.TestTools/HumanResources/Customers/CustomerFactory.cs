using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos;

namespace Neximous.WorkShop.TestTools.HumanResources.Customers
{
    public static class CustomerFactory
    {
        public static AddCustomerDto Give_Customer_AddDto(this Generator generator)
        {
            return new AddCustomerDto()
            {
                UserName = "dummy_UserName",
                FirstName = "dummy_FirstName",
                LastName = "dummy_LastName",
                Gender = Gender.Male,
                ContactInfo = new AddCustomerContactInfoDto()
                {
                    CountryCallingCode = "98",
                    MobileNumber = "9384834683",
                    Email = "pranceoffire50@gmail.com"
                },
                Addresses =
                    new List<AddCustomerAddressDto>()
                    {
                        new AddCustomerAddressDto("address","country","city","postalCode")
                    },

                ProfilePicture = new AddCustomerProfilePictureDto()
                {
                    ImageId = Guid.NewGuid().ToString(),
                    ImageExtension = "PNG"
                }
            };
        }
    }
}
