using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        private string role;

        public string Role
        {
            get { return role; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Role cannot be null or empty.");
                }
                role = value.Trim();
            }
        }

        public ICollection<Authority> Authorities { get; set; }
        public ICollection<User> Users { get; set; }

        public Roles()
        {
            Authorities = new List<Authority>();
            Users = new List<User>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Role ID: {Id}");
            sb.AppendLine($"Role: {Role}");
            sb.AppendLine("Authorities:");

            if (Authorities != null && Authorities.Count > 0)
            {
                foreach (Authority authority in Authorities)
                {
                    sb.AppendLine($"- {authority.Name}");
                }
            }

            sb.AppendLine("Users:");
            if (Users != null && Users.Count > 0)
            {
                foreach (User user in Users)
                {
                    sb.AppendLine($"- {user.Email}");
                }
            }

            return sb.ToString();
        }
    }
}
