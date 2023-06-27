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

        public Roles GetRoleByRole(String role)
        {
            return rolesCollection.Find(role => role.Role.Equals(role)).FirstOrDefault();
        }

        public void CreateRole(Roles role)
        {
            rolesCollection.InsertOne(role);
        }

        public void UpdateRole(ObjectId roleId, Roles updatedRole)
        {
            rolesCollection.ReplaceOne(role => role.Id == roleId, updatedRole);
        }

        public void DeleteRole(ObjectId roleId)
        {
            rolesCollection.DeleteOne(role => role.Id == roleId);
        }
    }
}
