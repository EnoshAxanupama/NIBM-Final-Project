using BixbyShop_LK.Users_and_Roles;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Services
{
    public static class RolesService
    {
        private static MongoClient client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
        private static IMongoDatabase database = client.GetDatabase("BixbyShop_LK");
        private static readonly IMongoCollection<Role> rolesCollection = RolesService.database.GetCollection<Role>("Roles");

        public static Role GetRoleByRole(string roleName)
        {
            var filter = Builders<Role>.Filter.Eq("UserRole", roleName);
            return rolesCollection.Find(filter).FirstOrDefault();
        }

        public static Role GetRoleByNameViaList(string roleName)
        {
            return GetAllRoles().Find(role=> role.UserRole == roleName);
        }

        public static List<Role> GetAllRoles()
        {
            return rolesCollection.Find(_ => true).ToList();
        }

        public static Role GetRoleById(string roleId)
        {
            var objectId = new ObjectId(roleId);
            return rolesCollection.Find(role => role.Id == objectId).FirstOrDefault();
        }

        public static void CreateRole(Role role)
        {
            rolesCollection.InsertOne(role);
        }

        public static void UpdateRole(string roleId, Role updatedRole)
        {
            var objectId = new ObjectId(roleId);
            rolesCollection.ReplaceOne(role => role.Id == objectId, updatedRole);
        }

        public static void UpdateRole(ObjectId roleId, Role updatedRole)
        {
            rolesCollection.ReplaceOne(role => role.Id == roleId, updatedRole);
        }

        public static void DeleteRole(string roleId)
        {
            var objectId = new ObjectId(roleId);
            rolesCollection.DeleteOne(role => role.Id == objectId);
        }
    }
}
