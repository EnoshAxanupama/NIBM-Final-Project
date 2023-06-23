using BixbyShop_LK.Models.Order;
using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Models.Comments
{
    public class Comment
    {
        [Key]
        private long id;
        private String comment;

        private User user;
        private long userId;


        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public String UserComment
        {
            get { return comment; }
            set { comment = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
