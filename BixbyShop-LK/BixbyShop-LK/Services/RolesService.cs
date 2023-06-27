using BixbyShop_LK.Users_and_Roles;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace BixbyShop_LK.Services
{
    public class RolesService
    {
        private readonly IMongoCollection<Role> rolesCollection;
        private readonly IMongoDatabase database;

        public RolesService(MongoDbContext mongoDbContext)
        {
            rolesCollection = mongoDbContext.Roles;
        }

        public RolesService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
            rolesCollection = database.GetCollection<Role>("Roles");
        }

        public Role GetRoleByRole(string roleName)
        {
            var filter = Builders<Role>.Filter.Eq("UserRole", roleName);
            return rolesCollection.Find(filter).FirstOrDefault();
        }

        public List<Role> GetAllRoles()
        {
            return rolesCollection.Find(_ => true).ToList();
        }

        public Role GetRoleById(string roleId)
        {
            var objectId = new ObjectId(roleId);
            return rolesCollection.Find(role => role.Id == objectId).FirstOrDefault();
        }

        public void CreateRole(Role role)
        {
            rolesCollection.InsertOne(role);
        }

        public void UpdateRole(string roleId, Role updatedRole)
        {
            var objectId = new ObjectId(roleId);
            rolesCollection.ReplaceOne(role => role.Id == objectId, updatedRole);
        }

        public void UpdateRole(ObjectId roleId, Role updatedRole)
        {
            rolesCollection.ReplaceOne(role => role.Id == roleId, updatedRole);
        }

        public void DeleteRole(string roleId)
        {
            var objectId = new ObjectId(roleId);
            rolesCollection.DeleteOne(role => role.Id == objectId);
        }
    }
}
