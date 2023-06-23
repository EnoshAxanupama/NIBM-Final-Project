using System.ComponentModel.DataAnnotations;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Authority
    {
        [Key]
        private string name;
        private ICollection<Roles> roles;

        public Authority()
        {
            roles = new List<Roles>();
        }

        public string Name
        {
            get { return name; }
            set { name = value?.Trim(); }
        }

        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
