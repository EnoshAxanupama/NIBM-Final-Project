using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Roles
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Role")]
        public String Role { get; set; }

        public Authority[] Authorities { get; set; }
        public User[] Users { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Role ID: {Id}");
            sb.AppendLine($"Role: {Role}");
            sb.AppendLine("Authorities:");

            if (Authorities != null && Authorities.Length > 0)
            {
                foreach (Authority authority in Authorities)
                {
                    sb.AppendLine($"- {authority.Name}");
                }
            }

            sb.AppendLine("Users:");
            if (Users != null && Users.Length > 0)
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
