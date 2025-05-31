using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos;

namespace Neximous.WorkShop.TestTools.HumanResources.Customers
{
    public static class CustomerFactory
    {
        public static Customer Give_Customer(
            this Generator generator)
        {
            return new Customer()
            {
                UserName = "dummy_UserName",
                FirstName = "dummy_FirstName",
                LastName = "dummy_LastName",
                Identifire = "dummy_Identifire",
                CreationDate = DateTime.Now,
                OrderNumber = 0,
                RegistrationDate = DateTime.Now,
                IsActive = true,
                Gender = Gender.Male,
                ContactInfo = new UserContactInfo()
                {
                    CountryCallingCode = "98",
                    MobileNumber = "9384834683",
                    Email = "pranceoffire50@gmail.com"
                },
                Addresses =
                   new HashSet<UserAddress>()
                   {
                        new UserAddress()
                        {
                            Address = "address",
                             Country = "country",
                            City = "city",
                            PostalCode = "postalCode"
                        }
                   },

                ProfilePicture = new UserProfilePicture()
                {
                    ImageId = Guid.NewGuid().ToString(),
                    ImageExtension = "PNG"
                }
            };
        }

        public static AddCustomerDto Give_Customer_AddDto(this Generator generator)
        {
            return new AddCustomerDto()
            {
                UserName = "dummy_UserName",
                FirstName = "dummy_FirstName",
                LastName = "dummy_LastName",
                Gender = Gender.Male,
                ContactInfo = new AddCustomerContactInformationDto()
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

        public static UpdateCustomerDto Give_Customer_UpdateDto(this Generator generator)
        {
            return new UpdateCustomerDto()
            {
                UserName = "dummy_UserName",
                FirstName = "dummy_FirstName",
                LastName = "dummy_LastName",
                Gender = Gender.Male,
                ContactInfo = new UpdateCustomerContactInformationDto()
                {
                    CountryCallingCode = "98",
                    MobileNumber = "9384834683",
                    Email = "pranceoffire50@gmail.com"
                },
                Addresses =
                    new UpdateCustomerAddressDto()
                    {
                        DeletedIds = new List<long>(),
                        NewAddresses = new List<AddCustomerAddressDto>()
                    },

                ProfilePicture = new UpdateCustomerProfilePictureDto()
                {
                    ImageId = Guid.NewGuid().ToString(),
                    ImageExtension = "PNG"
                }
            };
        }
    }

    public class CustomerBuilder()
    {
        public AddCustomerDto customer = new AddCustomerDto()
        {
            UserName = "dummy_UserName",
            FirstName = "dummy_FirstName",
            LastName = "dummy_LastName",
            Gender = Gender.Male,
            ContactInfo = new AddCustomerContactInformationDto()
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


        public CustomerBuilder WithUserName(string userName)
        {
            customer.UserName = userName;
            return this;
        }
        public CustomerBuilder WithFirstName(string firstName)
        {
            customer.FirstName = firstName;
            return this;
        }
        public CustomerBuilder WithLast(string lastName)
        {
            customer.LastName = lastName;
            return this;
        }

        public AddCustomerDto Build()
        {
            return customer;
        }
    }
}
