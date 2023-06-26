using BixbyShop_LK.Models.Comments;
using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Models.Item
{
    public class ShopItem
    {
        [Key]
        private long id;
        private string name;
        private string description;
        private int price;

        private ICollection<Comment> comments;

        public ShopItem()
        {
            comments = new List<Comment>();
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
