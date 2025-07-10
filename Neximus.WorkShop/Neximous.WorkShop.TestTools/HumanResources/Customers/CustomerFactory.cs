using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;

namespace Neximous.WorkShop.TestTools.HumanResources.Customers;

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
            UserAddresses =
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

    public static AddCustomerDTO Give_Customer_AddDto(this Generator generator)
    {
        return new AddCustomerDTO()
        {
            UserName = "dummy_UserName",
            FirstName = "dummy_FirstName",
            LastName = "dummy_LastName",
            Gender = Gender.Male,
            ContactInfo = new AddCustomerContactInfoDTO()
            {
                CountyCallingCode = "98",
                MobileNumber = "9384834683",
                Email = "pranceoffire50@gmail.com"
            },
            UserAddresses =
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

    public static UpdateCustomerDTO Give_Customer_UpdateDto(this Generator generator)
    {
        return new UpdateCustomerDTO()
        {
            UserName = "dummy_UserName",
            FirstName = "dummy_FirstName",
            LastName = "dummy_LastName",
            Gender = Gender.Male,
            ContactInfo = new UpdateCustomerContactInformationDTO()
            {
                CountryCallingCode = "98",
                MobileNumber = "9384834683",
                Email = "pranceoffire50@gmail.com"
            },
            Addresses =
                new UpdateCustomerAddressDTO()
                {
                    DeletedIds = new List<long>(),
                    NewAddresses = new List<AddCustomerAddressDTO>()
                },

            ProfilePicture = new UpdateCustomerProfilePictureDTO()
            {
                ImageId = Guid.NewGuid().ToString(),
                ImageExtension = "PNG"
            }
        };
    }


    public class CustomerBuilder()
    {
        public AddCustomerDTO customer = new AddCustomerDTO()
        {
            UserName = "dummy_UserName",
            FirstName = "dummy_FirstName",
            LastName = "dummy_LastName",
            Gender = Gender.Male,
            ContactInfo = new AddCustomerContactInfoDTO()
            {
                CountyCallingCode = "98",
                MobileNumber = "9384834683",
                Email = "pranceoffire50@gmail.com"
            },
            UserAddresses =
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

        public AddCustomerDTO Build()
        {
            return customer;
        }
    }
}