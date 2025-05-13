using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neximus.WorkShop.Domain.Orders.Items;
using Neximus.WorkShop.Persistance.Orders.Orders;
using Neximus.WorkShop.Persistance.Products.Products;

namespace Neximus.WorkShop.Persistance.Orders.Items
{
    public class OrderItemEntityMap : IEntityTypeConfiguration<OrderItem>
    {
        //public long Id { get; set; }
        //public long OrderId { get; set; }
        //public Order Order { get; set; }
        //public long ProductId { get; set; }
        //public Product Product { get; set; }
        //public int Quantity { get; set; }
        //public decimal PricePerProduct { get; set; }
        //public decimal TotalPrice { get; set; }
        //public decimal TotalDiscount { get; set; }

        public void Configure(EntityTypeBuilder<OrderItem> _)
        {
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Quantity);
            _.Property(_ => _.OrderId);
            _.HasOne(o => o.Order);
            _.Property(_ => _.ProductId);
            _.HasOne(o => o.Product);
            _.Property(_ => _.PricePerProduct);
            _.Property(_ => _.TotalPrice);
            _.Property(_ => _.TotalDiscount);
        }

    }
}