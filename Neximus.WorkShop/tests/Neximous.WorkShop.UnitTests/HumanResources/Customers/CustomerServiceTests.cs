using FluentAssertions;
using FluentGenerator;
using Microsoft.EntityFrameworkCore;
using Moq;
using Neximous.WorkShop.TestTools.HumanResources.Customers;
using Neximous.WorkShop.TestTools.Infrastructures;
using Neximus.WorkShop.Domain.HumanResources.Customers;
using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Persistance.Infrastructures;
using Neximus.WorkShop.Services.HumanResources.Customers.Contracts;

namespace Neximous.WorkShop.UnitTests.HumanResources.Customers
{
    public class CustomerServiceTests
    {
        public ICustomerService Sut { get; }
        public EFDataContext Context { get; }

        public CustomerServiceTests()
        {
            var iCustomerRepositoryMoq = new Mock<ICustomerRepository>();
            iCustomerRepositoryMoq.Setup(_ => _.Add(It.IsAny<Customer>())).Throws<Exception>();

            var mockedParameter = AutoServiceTools.MockObjectListCreator();
            mockedParameter.AddMockedParameter(typeof(ICustomerRepository), iCustomerRepositoryMoq.Object);

            var integrationSut = new IntegrationSut<ICustomerService>(mockedParameter);

            Sut = integrationSut.Sut;
            Context = integrationSut.Context;
        }

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
    }
}
