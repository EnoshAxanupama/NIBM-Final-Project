using BixbyShop_LK.Users_and_Roles;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Order;

namespace BixbyShop_LK
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long id;
        private string firstName;
        private string lastName;
        private string email;
        private string address;
        private string password;
        private string pic;

        private ICollection<Roles> roles;
        private ICollection<Order> orders;
        private ICollection<CartAndOrder> cart;
        private ICollection<Comment> comments;

        public User()
        {
            roles = new List<Roles>();
            orders = new List<Order>();
            cart = new List<CartAndOrder>();
            comments = new List<Comment>();
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value?.Trim(); }
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

        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public ICollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public ICollection<CartAndOrder> Cart
        {
            get { return cart; }
            set { cart = value; }
        }

        public ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
