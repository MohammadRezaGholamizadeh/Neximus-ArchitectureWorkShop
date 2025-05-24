namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos
{
    public record AddCustomerAddressDto(
        string address,
        string country,
        string city,
        string postalCode);
}
