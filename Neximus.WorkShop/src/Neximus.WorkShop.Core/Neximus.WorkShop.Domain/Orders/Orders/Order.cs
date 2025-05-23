using Neximus.WorkShop.Domain.HumanResources.Users;
using Neximus.WorkShop.Domain.Orders.Items;

namespace Neximus.WorkShop.Domain.Orders.Orders
{
    public class Order
    {
        public Order()
        {
            items = new List<OrderItem>();
        }
        public long Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public List<OrderItem> items { get; set; }
    }
}
