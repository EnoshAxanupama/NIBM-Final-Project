using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Item;
using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Users_and_Roles;
using MongoDB.Driver;

namespace BixbyShop_LK.Config
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }
        public IMongoCollection<User> Users => database.GetCollection<User>("Users");
        public IMongoCollection<Roles> Roles => database.GetCollection<Roles>("Roles");
        public IMongoCollection<Authority> Authorities => database.GetCollection<Authority>("Authorities");
        public IMongoCollection<Order> Orders => database.GetCollection<Order>("Orders");
        public IMongoCollection<CartAndOrder> CartAndOrders => database.GetCollection<CartAndOrder>("Cartandorders");
        public IMongoCollection<ShopItem> ShopItems => database.GetCollection<ShopItem>("Shopitems");
        public IMongoCollection<Comment> Comments => database.GetCollection<Comment>("Comments");
    }
}
