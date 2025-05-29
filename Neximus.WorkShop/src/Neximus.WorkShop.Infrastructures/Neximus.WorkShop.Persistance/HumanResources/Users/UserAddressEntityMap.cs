using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Persistance.HumanResources.Users
{
    public class UserAddressEntityMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> _)
        {
            _.ToTable("UserAddresses");
            
            _.HasKey(x => x.Id);
            
            _.Property(x => x.Id).ValueGeneratedOnAdd();

            _.Property(x => x.Address).IsRequired().HasMaxLength(2000);
            
            _.Property(x => x.City).IsRequired().HasMaxLength(250);
            
            _.Property(x => x.Country).IsRequired().HasMaxLength(250);
            
            _.Property(x => x.PostalCode).IsRequired().HasMaxLength(250);
            
            // TODO: Realation must be done.

            _.HasOne(_ => _.User).WithMany(_=>_.UserAddresses)
                .HasForeignKey(_ => _.UserId);

        }
    }
    
    // public class UserAddressEntityMap
    // {
    //     public long Id { get; set; }
    //     public string UserId { get; set; }
    //     public UserEntityMap UserEntityMap { get; set; }
    //     public string Address { get; set; }
    //     public string Country { get; set; }
    //     public string City { get; set; }
    //     public string PostalCode { get; set; }
    // }
}
