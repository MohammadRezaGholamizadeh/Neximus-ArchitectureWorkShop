using Neximus.WorkShop.Domain.Carts.Carts;
using Neximus.WorkShop.Domain.Products.Products;

namespace Neximus.WorkShop.Domain.Carts.Items
{
    public class CartItem
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public Cart Cart { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
