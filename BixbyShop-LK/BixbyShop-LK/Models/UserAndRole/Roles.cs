using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long id;

        private string role;

        private ICollection<Authority> authorities;
        private ICollection<User> users;

        public Roles()
        {
            authorities = new List<Authority>();
            users = new List<User>();
        }
        public long Id
        {
            get { return id; }
            set { id = value; }
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
