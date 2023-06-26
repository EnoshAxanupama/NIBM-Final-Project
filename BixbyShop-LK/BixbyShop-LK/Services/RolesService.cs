using BixbyShop_LK.Config;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Users_and_Roles.Services
{
    public class RolesService
    {
        private readonly IMongoCollection<Roles> rolesCollection;
        private readonly MongoDBContext mongoDBContext;

        public RolesService(IMongoDatabase database)
        {
            rolesCollection = database.GetCollection<Roles>("roles");
        }

        public RolesService(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
            rolesCollection = mongoDBContext.Roles;
        }

        public List<Roles> GetAllRoles()
        {
            return rolesCollection.Find(_ => true).ToList();
        }

        public Roles GetRoleById(string roleId)
        {
            var objectId = new ObjectId(roleId);
            return rolesCollection.Find(role => role.Id == objectId).FirstOrDefault();
        }

        public void CreateRole(Roles role)
        {
            rolesCollection.InsertOne(role);
        }

        public void UpdateRole(string roleId, Roles updatedRole)
        {
            var objectId = new ObjectId(roleId);
            rolesCollection.ReplaceOne(role => role.Id == objectId, updatedRole);
        }

        public void DeleteRole(string roleId)
        {
            var objectId = new ObjectId(roleId);
            rolesCollection.DeleteOne(role => role.Id == objectId);
        }
    }
}
