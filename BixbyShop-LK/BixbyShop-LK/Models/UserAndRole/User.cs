using BixbyShop_LK.Users_and_Roles;
using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Order;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BixbyShop_LK
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String Password { get; set; }
        public String Pic { get; set; }
        public bool EmailVerify { get; set; }
        public Role[] Roles { get; set; }
        public Order[] Orders { get; set; }
        public CartAndOrder[] Cart { get; set; }
        public Comment[] Comments { get; set; }

    }
}
