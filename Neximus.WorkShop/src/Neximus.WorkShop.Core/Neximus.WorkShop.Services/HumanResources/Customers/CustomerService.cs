using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;
using Neximus.WorkShop.Services.Infrastructures.Contracts;

namespace Neximus.WorkShop.Services.HumanResources.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(AddCustomerDTO dto)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsActive = true,
                CreationDate = DateTime.UtcNow,
                Gender = Gender.Male,
                RegistrationDate = DateTime.UtcNow,
                ProfilePicture = new UserProfilePicture()
                {
                    ImageId = dto.ProfilePicture.ImageId,
                    ImageExtension = dto.ProfilePicture.ImageExtention,
                },
                ContactInfo = new UserContactInfo()
                {
                    CountryCallingCode = dto.ContactInfo.CountyCallingCode,
                    Email = dto.ContactInfo.Email,
                    MobileNumber = dto.ContactInfo.MobileNumber,
                },
                UserAddresses = dto.Addresses.Select(_ => new UserAddress()
                {
                    Address = _.address,
                    City = _.city,
                    PostalCode = _.postalCode,
                    Country = _.country,
                }).ToHashSet(),
                Identifire = Guid.NewGuid().ToString(),
                OrderNumber = 0
            };

            _customerRepository.Add(customer);
            await _unitOfWork.Save();

            return customer.Id;
        }
    }
}
