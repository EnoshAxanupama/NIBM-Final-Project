using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Authority
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public String Name { get; set; }
        public Roles[] Roles { get; set; }
        public override string ToString()
        {
            return $"Authority ID: {Id}, Name: {Name}";
        }
    }
}
