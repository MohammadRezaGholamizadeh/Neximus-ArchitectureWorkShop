using Neximus.WorkShop.Domain.Carts.Items;
using Neximus.WorkShop.Domain.HumanResources.Users;

namespace Neximus.WorkShop.Domain.Carts.Carts;

public class Cart
{
    public Cart()
    {
        Items = new HashSet<CartItem>();
    }
    public long Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public DateTime ModificationDate { get; set; }
    public DateTime CreationDate { get; set; }
    public HashSet<CartItem> Items { get; set; }
}
