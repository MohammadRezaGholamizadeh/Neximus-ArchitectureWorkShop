using FluentAssertions;
using FluentGenerator;
using Microsoft.EntityFrameworkCore;
using Moq;
using Neximous.WorkShop.TestTools.HumanResources.Customers;
using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.HumanResources.Customers;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;

namespace Neximous.WorkShop.UnitTests.HumanResources.Customers;

public class CustomerServiceTests : IntegrationSut<ICustomerService>
{
    [Fact]
    public async Task Add_Customer_Properly()
    {
        var dto = Generator.Engine.Give_Customer_AddDTO()
            .UpdateWithValue(_ => _.Gender = Gender.Male)
            .UpdateWithValue(_ => _.FirstName = "Dummy_Iman");

        string id = await Sut.Add(dto);

        var expected = await Context.Customers.SingleAsync();
        expected.UserName.Should().Be(dto.UserName);
        expected.FirstName.Should().Be(dto.FirstName);
        expected.LastName.Should().Be(dto.LastName);
        expected.Gender.Should().Be(dto.Gender);
        expected.ContactInfo.MobileNumber.Should().Be(dto.ContactInfo.MobileNumber);
        expected.ContactInfo.CountryCallingCode.Should().Be(dto.ContactInfo.CountyCallingCode);
        expected.ContactInfo.Email.Should().Be(dto.ContactInfo.Email);
        expected.ProfilePicture.Should().Be(dto.ProfilePicture);

        var expectedAddress = expected.UserAddresses.Single();
        var dtoAddresses = dto.Addresses.Single();
        expectedAddress.Address.Should().Be(dtoAddresses.address);
        expectedAddress.City.Should().Be(dtoAddresses.city);
        expectedAddress.Country.Should().Be(dtoAddresses.country);
        expectedAddress.PostalCode.Should().Be(dtoAddresses.postalCode);
    }
}