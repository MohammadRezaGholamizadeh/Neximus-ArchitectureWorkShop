namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.Dtos
{
    public class UpdateCustomerAddressDto
    {
        public UpdateCustomerAddressDto()
        {
            DeletedIds = new List<long>();
            NewAddresses = new List<AddCustomerAddressDto>();
        }
        public List<long> DeletedIds { get; set; }
        public List<AddCustomerAddressDto> NewAddresses { get; set; }
    }
}
