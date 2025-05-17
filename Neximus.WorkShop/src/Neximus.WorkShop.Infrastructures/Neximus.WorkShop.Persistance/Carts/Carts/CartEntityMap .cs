using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Carts;

namespace Neximus.WorkShop.Persistance.Carts.Carts;

public class CartEntityMap: IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> _)
    {
        _.ToTable("Cart");

        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).ValueGeneratedOnAdd();

        _.Property(_ => _.UserId).IsRequired().HasMaxLength(450);

        _.Property(_ => _.ModificationDate).IsRequired();
        _.Property(_ => _.CreationDate).IsRequired();

        _.HasOne(_ => _.User)
            .WithMany(_ => _.Carts)
            .HasForeignKey(_ => _.UserId);
    }
}