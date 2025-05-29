using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Carts.Items;


namespace Neximus.WorkShop.Persistance.Carts.Items
{
    public class CartItemEntityMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> _)
        {
            _.ToTable("CartItems");
            
            _.HasKey(_ => _.Id);
            
            _.Property(_ => _.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.CartId).IsRequired();
            
            _.Property(_ => _.ProductId).IsRequired();
            
            _.Property(_ => _.Quantity).IsRequired();
            
            // TODO : Relations must be done.


            _.HasOne(_ => _.Cart)
                .WithMany(_ => _.CartItems)
                .HasForeignKey(f => f.CartId);

            _.HasOne(_ => _.Product)
                .WithMany(_ => _.CartItems)
                .HasForeignKey(f => f.ProductId);

        }
    }

   // public class CartItemEntityMap
   //    {
   //        public long Id { get; set; }
   //        public long CartId { get; set; }
   //        public Cart Cart { get; set; }
   //        public long ProductId { get; set; }
   //        public Product Product { get; set; }
   //        public int Quantity { get; set; }
   //    }
}
