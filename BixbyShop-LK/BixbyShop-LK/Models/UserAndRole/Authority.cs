using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Authority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long id;

        private string name;
        private ICollection<Roles> roles;

        public Authority()
        {
            roles = new List<Roles>();
        }
        public long Id
        {
            get { return id; }
            set { id = value; }
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
