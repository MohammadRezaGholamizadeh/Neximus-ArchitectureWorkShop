using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos;
using Neximus.WorkShop.Services.HumanResources.Customers.Exceptions;
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

        public async Task Update(string id, UpdateCustomerDto dto)
        {
            var customer = await _repository.FindById(id);

            GuardIfCustomerNotExist(customer!);
            GuardIfCustomerNotInActiveStatus(customer!.IsActive);

            customer.UserName = dto.UserName;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Gender = dto.Gender;

            customer.ContactInfo.MobileNumber = dto.ContactInfo.MobileNumber;
            customer.ContactInfo.CountryCallingCode = dto.ContactInfo.CountryCallingCode;
            customer.ContactInfo.Email = dto.ContactInfo.Email;

            customer.ProfilePicture.ImageId = dto.ProfilePicture.ImageId;
            customer.ProfilePicture.ImageExtension = dto.ProfilePicture.ImageExtension;

            customer.Addresses
                    .RemoveWhere(
                        _ => dto.Addresses
                                .DeletedIds
                                .Contains(_.Id));
            customer.Addresses
                    .UnionWith(
                        dto.Addresses
                           .NewAddresses
                           .Select(_ =>
                              new UserAddress()
                              {
                                  Address = _.address,
                                  Country = _.country,
                                  City = _.city,
                                  PostalCode = _.postalCode,
                              })
                           .ToHashSet());

            _repository.Update(customer);

            await _unitOfWork.Save();
        }

        public async Task DeleteById(string id)
        {
            var customer = await _repository.FindById(id);
            GuardIfCustomerNotExist(customer);
            GuardIfCustomerBeActive(customer!.IsActive);

            _repository.Delete(customer);

            await _unitOfWork.Save();
        }






        private static void GuardIfCustomerBeActive(bool isActive)
        {
            if (isActive)
                throw new CustomerBeActiveException();
        }

        private static void GuardIfCustomerNotInActiveStatus(bool isActive)
        {
            if (!isActive)
                throw new CustomerIsInActiveStateException();
        }

        private static void GuardIfCustomerNotExist(Customer? customer)
        {
            if (customer == null)
                throw new CustomerNotExistException();
        }
    }
}
