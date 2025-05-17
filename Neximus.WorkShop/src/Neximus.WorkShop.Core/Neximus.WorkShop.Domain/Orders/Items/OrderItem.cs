using Neximus.WorkShop.Domain.Orders.Orders;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Domain.Orders.Items;

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
