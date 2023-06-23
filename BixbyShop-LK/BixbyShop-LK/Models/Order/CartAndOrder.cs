using BixbyShop_LK.Models.Item;
using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Models.Order
{
    public class CartAndOrder
    {
        [Key]
        private long id;
        private ShopItem item;
        private User user;

        private int quantity;
        private int price;

        public ShopItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
