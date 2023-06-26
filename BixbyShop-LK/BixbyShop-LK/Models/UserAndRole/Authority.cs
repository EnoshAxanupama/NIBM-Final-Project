using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Role cannot be null or empty.");
                }
                name = value.Trim();
            }
        }

        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public override string ToString()
        {
            return $"Authority ID: {Id}, Name: {Name}";
        }
    }
}
