using BixbyShop_LK;
using BixbyShop_LK.Config;
using BixbyShop_LK.Services;
using BixbyShop_LK.Users_and_Roles;
using BixbyShop_LK.Users_and_Roles.Services;
using Microsoft.VisualBasic.ApplicationServices;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShopApp_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MongoDBContext mongoDBContext = new MongoDBContext(EnvironmentService.getEnvironmentVariable("MonoDBUrl"), EnvironmentService.getEnvironmentVariable("MonoDBName"));
            //MongoDBContext mongoDBContext = new MongoDBContext("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=DEFAULT", "NIBM");
            MongoDBContext mongoDBContext = new MongoDBContext("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256", "NIBM");

            var userService = new UserService(mongoDBContext);
            var rolesService = new RolesService(mongoDBContext);
            var authorityService = new AuthorityService(mongoDBContext);

            Roles role = new Roles
            {
                Role = "User"
            };

            rolesService.CreateRole(role);

            /*var client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
            var database = client.GetDatabase("NIBM");
            var collection = database.GetCollection<BsonDocument>("Roles");

            Roles role = new Roles
            {
                Role = "User"
            };

            var document = role.ToBsonDocument();
            collection.InsertOne(document);*/


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}