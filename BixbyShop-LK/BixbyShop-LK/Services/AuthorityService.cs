using BixbyShop_LK.Users_and_Roles;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Services
{
    public class AuthorityService
    {
        private readonly IMongoCollection<Authority> authorityCollection;

        public AuthorityService(MongoDbContext mongoDbContext)
        {
            authorityCollection = mongoDbContext.Authorities;
        }

        public Authority GetAuthorityByName(string name)
        {
            var filter = Builders<Authority>.Filter.Eq("Name", name);
            return authorityCollection.Find(filter).FirstOrDefault();
        }

        public List<Authority> GetAllAuthorities()
        {
            return authorityCollection.Find(_ => true).ToList();
        }

        public Authority GetAuthorityById(string authorityId)
        {
            var objectId = new ObjectId(authorityId);
            return authorityCollection.Find(authority => authority.Id == objectId).FirstOrDefault();
        }

        public void CreateAuthority(Authority authority)
        {
            authorityCollection.InsertOne(authority);
        }

        public void CreateAuthority(List<Authority> authorities)
        {
            authorityCollection.InsertMany(authorities);
        }

        public void UpdateAuthority(string authorityId, Authority updatedAuthority)
        {
            var objectId = new ObjectId(authorityId);
            authorityCollection.ReplaceOne(authority => authority.Id == objectId, updatedAuthority);
        }

        public void DeleteAuthority(string authorityId)
        {
            var objectId = new ObjectId(authorityId);
            authorityCollection.DeleteOne(authority => authority.Id == objectId);
        }
    }
}
