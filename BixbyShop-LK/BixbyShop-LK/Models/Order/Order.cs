using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Models.Order
{
    public class Order
    {
        [Key]
        private long id;
        private ICollection<CartAndOrder> items;
        private User user;
        private int price;

        public ICollection<CartAndOrder> Items
        {
            get { return items; }
            set { items = value; }
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

        public int Price
        {
            get { return price; }
            set { price = value; }
        }


    }
}
