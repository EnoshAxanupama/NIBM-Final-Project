using BixbyShop_LK.Models.Item;
using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Models.Comments
{
    public class Comment
    {
        [Key]
        private long id;
        private string comment;

        private User user;
        private long userId;

        private ShopItem shopItem;
        private long shopItemId;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserComment
        {
            get { return comment; }
            set { comment = value; }
        }

        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public long ShopItemId
        {
            get { return shopItemId; }
            set { shopItemId = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public ShopItem ShopItem
        {
            get { return shopItem; }
            set { shopItem = value; }
        }
    }
}
