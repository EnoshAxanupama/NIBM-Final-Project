using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Users_and_Roles;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Services
{
    public static class AuthorityService
    {
        private static MongoClient client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
        private static IMongoDatabase database = client.GetDatabase("BixbyShop_LK");
        private static IMongoCollection<Authority> authorityCollection = database.GetCollection<Authority>("AuthorityServices");

        public static Authority GetAuthorityByName(string name)
        {
            var filter = Builders<Authority>.Filter.Eq("Name", name);
            return authorityCollection.Find(filter).FirstOrDefault();
        }

        public static Authority GetAuthorityByNameViaList(string name)
        {
            return GetAllAuthorities().Find(au => au.Name == name);
        }

        public static List<Authority> GetAllAuthorities()
        {
            return authorityCollection.Find(_ => true).ToList();
        }

        public static Authority GetAuthorityById(string authorityId)
        {
            var objectId = new ObjectId(authorityId);
            return authorityCollection.Find(authority => authority.Id == objectId).FirstOrDefault();
        }

        public static void CreateAuthority(Authority authority)
        {
            authorityCollection.InsertOne(authority);
        }

        public static void CreateAuthority(List<Authority> authorities)
        {
            authorityCollection.InsertMany(authorities);
        }

        public static void UpdateAuthority(string authorityId, Authority updatedAuthority)
        {
            var objectId = new ObjectId(authorityId);
            authorityCollection.ReplaceOne(authority => authority.Id == objectId, updatedAuthority);
        }

        public static void DeleteAuthority(string authorityId)
        {
            var objectId = new ObjectId(authorityId);
            authorityCollection.DeleteOne(authority => authority.Id == objectId);
        }
    }
}
