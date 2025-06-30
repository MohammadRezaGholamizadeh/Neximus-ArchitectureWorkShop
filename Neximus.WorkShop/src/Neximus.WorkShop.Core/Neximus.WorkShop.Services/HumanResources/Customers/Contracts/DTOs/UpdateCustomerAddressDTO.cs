namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs;

public class UpdateCustomerAddressDTO
{
    public UpdateCustomerAddressDTO()
    {
        DeletedIds = new List<long>();
        NewAddresses = new List<AddCustomerAddressDTO>();
    }

    public List<long> DeletedIds { get; set; }
    public List<AddCustomerAddressDTO> NewAddresses { get; set; }
}