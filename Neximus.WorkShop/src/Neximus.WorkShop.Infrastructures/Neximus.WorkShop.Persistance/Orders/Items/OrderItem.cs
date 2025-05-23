using Neximus.WorkShop.Persistance.Products.Products;
using Neximus.WorkShop.Persistence.Orders.Orders;
using Neximus.WorkShop.Persistence.Products.Products;

namespace Neximus.WorkShop.Persistance.Orders.Items
{
    public class OrderItem
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
    }
}
