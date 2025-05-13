using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserAddressEntityMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> _)
        {
            _.HasKey(x => x.Id);
            _.Property(_ => _.PostalCode);
            _.Property(_ => _.Address);
            _.Property(_ => _.Country);
            _.Property(_ => _.City);
            _.HasOne(x => x.User);

        }
    }
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public User User { get; set; }
    //    public string Address { get; set; }
    //    public string Country { get; set; }
    //    public string City { get; set; }
    //    public string PostalCode { get; set; }
    //}
}
