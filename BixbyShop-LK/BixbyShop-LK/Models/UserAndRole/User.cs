using BixbyShop_LK.Users_and_Roles;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Models.Comments;

namespace BixbyShop_LK
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long id;
        private String fistName;
        private String lastName;
        private String email;
        private String address;
        private String password;
        private String pic;

        private ICollection<Roles> roles;
        private ICollection<Order> orders;
        private ICollection<CartAndOrder> cart;
        private ICollection<Comment> comments;


        public ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public ICollection<CartAndOrder> Cart
        {
            get { return cart; }
            set { cart = value; }
        }

        public ICollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public string FirstName
        {
            get { return fistName; }
            set { fistName = value?.Trim(); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value?.Trim(); }
        }

        public string Email
        {
            get { return email; }
            set { email = value?.Trim(); }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Pic
        {
            get { return pic; }
            set { pic = value; }
        }
    }
}
