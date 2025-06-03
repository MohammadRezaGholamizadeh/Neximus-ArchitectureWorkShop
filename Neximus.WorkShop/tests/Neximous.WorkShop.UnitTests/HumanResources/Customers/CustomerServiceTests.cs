using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Neximous.WorkShop.TestTools.HumanResources.Customers;
using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;
using Neximus.WorkShop.Services.HumanResources.Customers.Exceptions;

namespace Neximous.WorkShop.UnitTests.HumanResources.Customers
{
    public class CustomerServiceTests : IntegrationSut<ICustomerService>
    {
        [Fact]
        public async Task Add_Customer_Properly()
        {
            var dto = Generator.Engine.Give_Customer_AddDto()
                                      .UpdateWithValue(_ => _.Gender = Gender.Male)
                                      .UpdateWithValue(_ => _.FirstName = "Zahra");

            string id = await Sut.Add(dto);

            var expected = await Context.Customres.SingleAsync();
            expected.UserName.Should().Be(dto.UserName);
            expected.FirstName.Should().Be(dto.FirstName);
            expected.LastName.Should().Be(dto.LastName);
            expected.Gender.Should().Be(dto.Gender);
            expected.ContactInfo.MobileNumber.Should().Be(dto.ContactInfo.MobileNumber);
            expected.ContactInfo.CountryCallingCode.Should().Be(dto.ContactInfo.CountryCallingCode);
            expected.ContactInfo.Email.Should().Be(dto.ContactInfo.Email);

            var expectedAddress = expected.Addresses.Single();
            var dtoAddresses = dto.Addresses.Single();
            expectedAddress.Address.Should().Be(dtoAddresses.address);
            expectedAddress.City.Should().Be(dtoAddresses.city);
            expectedAddress.Country.Should().Be(dtoAddresses.country);
            expectedAddress.PostalCode.Should().Be(dtoAddresses.postalCode);
        }

        [Fact]
        public async Task Update_Customer_properly()
        {
            var customer = Generator.Engine.Give_Customer()
                                           .UpdateWithValue(_ => _.FirstName = "محمدرضا");
            Save(customer);

            var dto = Generator.Engine.Give_Customer_UpdateDto()
                                      .UpdateWithValue(_ => _.FirstName = "محمد چه رضایی");

            await Sut.Update(customer.Id, dto);

            var expected = await Context.Customres.SingleOrDefaultAsync();
            expected.UserName.Should().Be(customer.UserName);
            expected.FirstName.Should().Be(dto.FirstName);
            expected.LastName.Should().Be(customer.LastName);
            expected.Gender.Should().Be(customer.Gender);
            expected.ContactInfo.MobileNumber.Should().Be(customer.ContactInfo.MobileNumber);
            expected.ContactInfo.CountryCallingCode.Should().Be(customer.ContactInfo.CountryCallingCode);
            expected.ContactInfo.Email.Should().Be(customer.ContactInfo.Email);

            var expectedAddress = expected.Addresses.Single();
            var dtoAddresses = customer.Addresses.Single();
            expectedAddress.Address.Should().Be(dtoAddresses.Address);
            expectedAddress.City.Should().Be(dtoAddresses.City);
            expectedAddress.Country.Should().Be(dtoAddresses.Country);
            expectedAddress.PostalCode.Should().Be(dtoAddresses.PostalCode);
        }

        [Fact]
        public async Task Delete_Customer_byId_properly()
        {
            var customer = Generator.Engine.Give_Customer()
                                           .UpdateWithValue(_ => _.FirstName = "محمدرضا")
                                           .UpdateWithValue(_ => _.IsActive = false);
            Save(customer);

            await Sut.DeleteById(customer.Id);

            var expected = await Context.Customres.ToListAsync();
            expected.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("invalidId")]
        public async Task Delete_Customer_byId_Shoud_Throw_Exception_when_Customer_not_exist(string invalidId)
        {
            var customer = Generator.Engine.Give_Customer().UpdateWithValue(_ => _.Id = "1");
            Save(customer);

            var expectedException =
                () => Sut.DeleteById(invalidId);

            await expectedException.Should().ThrowExactlyAsync<CustomerNotExistException>();

            var expected = await Context.Customres.SingleOrDefaultAsync();
            expected.UserName.Should().Be(customer.UserName);
            expected.FirstName.Should().Be(customer.FirstName);
            expected.LastName.Should().Be(customer.LastName);
            expected.Gender.Should().Be(customer.Gender);
            expected.ContactInfo.MobileNumber.Should().Be(customer.ContactInfo.MobileNumber);
            expected.ContactInfo.CountryCallingCode.Should().Be(customer.ContactInfo.CountryCallingCode);
            expected.ContactInfo.Email.Should().Be(customer.ContactInfo.Email);
        }

        [Fact]
        public async Task Delete_Customer_byId_Should_throw_exception_when_customer_be_active()
        {
            var customer = Generator.Engine
                                    .Give_Customer()
                                    .UpdateWithValue(_ => _.IsActive = true);
            Save(customer);

            var expectedException =
                () => Sut.DeleteById(customer.Id);

            await expectedException.Should().ThrowExactlyAsync<CustomerBeActiveException>();

            var expected = await Context.Customres.SingleOrDefaultAsync();
            expected.UserName.Should().Be(customer.UserName);
            expected.FirstName.Should().Be(customer.FirstName);
            expected.LastName.Should().Be(customer.LastName);
            expected.Gender.Should().Be(customer.Gender);
            expected.ContactInfo.MobileNumber.Should().Be(customer.ContactInfo.MobileNumber);
            expected.ContactInfo.CountryCallingCode.Should().Be(customer.ContactInfo.CountryCallingCode);
            expected.ContactInfo.Email.Should().Be(customer.ContactInfo.Email);
        }
    }
}
