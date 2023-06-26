using BixbyShop_LK.Config;
using MongoDB.Bson;
using MongoDB.Driver;


namespace BixbyShop_LK.Users_and_Roles.Services
{
    public class AuthorityService
    {
        private readonly IMongoCollection<Authority> authorityCollection;
        private readonly MongoDBContext mongoDBContext;

        public AuthorityService(IMongoDatabase database)
        {
            authorityCollection = database.GetCollection<Authority>("authorities");
        }
        public AuthorityService(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
            authorityCollection = this.mongoDBContext.Authorities;
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
