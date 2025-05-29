using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Items;
using Neximus.WorkShop.Persistance.Orders.Orders;
using Neximus.WorkShop.Persistance.Products.Products;

namespace Neximus.WorkShop.Persistance.Orders.Items
{
    public class OrderItemEntityMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> _)
        {
            _.ToTable("OrderItem");
            
            _.HasKey(x => x.Id);
            
            _.Property(x => x.Id).ValueGeneratedOnAdd();

            _.Property(x => x.OrderId).IsRequired();
            
            _.Property(x => x.ProductId).IsRequired();
            
            _.Property(x => x.Quantity).IsRequired();
            
            _.Property(x => x.PricePerProduct).IsRequired();
            
            _.Property(x => x.TotalPrice).IsRequired();
            
            _.Property(x => x.TotalDiscount).IsRequired();

            _.HasOne(_ => _.Order).WithMany(_ => _.OrderItems)
                .HasForeignKey(_ => _.OrderId);
            
            _.HasOne(_ => _.Product).WithMany(_ => _.OrderItems)
                .HasForeignKey(_ => _.ProductId);
        }
    }
    
    /*public class OrderItemEntityMap
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerProduct { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
    }*/
}
