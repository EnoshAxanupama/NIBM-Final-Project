using BixbyShop_LK.Models.Comments;
using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Models.Item
{
    public class ShopItem
    {
        [Key]
        private long id;
        private String name;
        private String description;
        private List<String> pics;
        private int price;

        private Comment comments;

        public Comment Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public List<String> Pics
        {
            get { return pics; }
            set { pics = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
