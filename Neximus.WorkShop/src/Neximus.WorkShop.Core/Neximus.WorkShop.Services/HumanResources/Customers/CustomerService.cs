using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos;
using Neximus.WorkShop.Services.Infrastructures.Contracts;

namespace Neximus.WorkShop.Services.HumanResources.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(
            ICustomerRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(AddCustomerDto dto)
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
                ProfilePicture =
                    new UserProfilePicture()
                    {
                        ImageId = dto.ProfilePicture.ImageId,
                        ImageExtension = dto.ProfilePicture.ImageExtension
                    },
                ContactInfo =
                    new UserContactInfo()
                    {
                        CountryCallingCode = dto.ContactInfo.CountryCallingCode,
                        Email = dto.ContactInfo.Email,
                        MobileNumber = dto.ContactInfo.MobileNumber,
                    },
                Addresses =
                    dto.Addresses
                       .Select(_ => new UserAddress()
                       {
                           Address = _.address,
                           Country = _.country,
                           City = _.city,
                           PostalCode = _.postalCode,
                       })
                       .ToHashSet(),
                OrderNumber = 0,
                Identifire = Guid.NewGuid().ToString()
            };

            _repository.Add(customer);
            await _unitOfWork.Save();

            return customer.Id;
        }
    }
}
