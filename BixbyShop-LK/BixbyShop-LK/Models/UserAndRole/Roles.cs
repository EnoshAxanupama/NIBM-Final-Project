using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Roles
    {
        [Key]
        private string role;

        private ICollection<Authority> authorities;
        private ICollection<User> users;

        public Roles()
        {
            authorities = new List<Authority>();
            users = new List<User>();
        }

        public string Role
        {
            get { return role; }
            set { role = value?.Trim(); }
        }

        public ICollection<Authority> Authorities
        {
            get { return authorities; }
            set { authorities = value; }
        }

        public ICollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }
    }
}
