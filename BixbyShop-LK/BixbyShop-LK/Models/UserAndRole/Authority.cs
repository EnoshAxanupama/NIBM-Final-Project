using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Authority
    {
        [Key]
        private String name;
        public string Name
        {
            get { return name; }
            set { name = value?.Trim(); }
        }

        private ICollection<Roles> roles;
        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
