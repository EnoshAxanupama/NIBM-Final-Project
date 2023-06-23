using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Roles
    {
        [Key]
        private String role;
        public string Role
        {
            get { return role; }
            set { role = value?.Trim(); }
        }

        private ICollection<Authority> authorities;

        public ICollection<Authority> Authorities
        {
            get { return authorities; }
            set { authorities = value; }
        }

        private ICollection<User> users;
        public ICollection<User> Users { 
            get { return users; } 
            set { users = value; }
        }
    }
}
