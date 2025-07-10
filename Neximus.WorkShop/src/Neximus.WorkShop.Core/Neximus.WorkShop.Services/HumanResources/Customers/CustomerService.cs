using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;
using Neximus.WorkShop.Services.HumanResources.Customers.Exceptions;
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
                UserAddresses = dto.UserAddresses.Select(_ => new UserAddress()
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

        public async Task Update(string id, UpdateCustomerDTO dto)
        {
            var customer = await _customerRepository.FindById(id);

            GuardIfCustomerNotExists(customer!);
            GuardIfCustomerIsNotInActiveStatus(customer!.IsActive);

            customer.UserName = dto.UserName;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Gender = dto.Gender;

            customer.ContactInfo.MobileNumber = dto.ContactInfo.MobileNumber;
            customer.ContactInfo.CountryCallingCode = dto.ContactInfo.CountryCallingCode;
            customer.ContactInfo.Email = dto.ContactInfo.Email;

            customer.ProfilePicture.ImageId = dto.ProfilePicture.ImageId;
            customer.ProfilePicture.ImageExtension = dto.ProfilePicture.ImageExtension;

            customer.UserAddresses
                .RemoveWhere(_ => dto.Addresses.DeletedIds.Contains(_.Id));

            customer.UserAddresses
                .UnionWith(
                    dto.Addresses.NewAddresses
                        .Select(_ => new UserAddress()
                        {
                            Address = _.address,
                            City = _.city,
                            PostalCode = _.postalCode,
                            Country = _.country,
                        }).ToHashSet());
            
            _customerRepository.Update(customer);

            await _unitOfWork.Save();
        }

        public async Task DeleteById(string id)
        {
            var customer = await _customerRepository.FindById(id);
            GuardIfCustomerNotExists(customer);
            GuardIfCustomerBeActive(customer!.IsActive);
            
            _customerRepository.Delete(customer);
            
            await _unitOfWork.Save();
        }


        private static void GuardIfCustomerBeActive(bool isActive)
        {
            if (isActive)
                throw new CustomerBeActiveException();
        }

        private static void GuardIfCustomerIsNotInActiveStatus(bool isActive)
        {
            if (!isActive)
                throw new CustomerIsInActiveStateException();
        }

        private static void GuardIfCustomerNotExists(Customer? customer)
        {
            if (customer == null)
            {
                throw new CustomerNotExistException();
            }
        }
    }
}