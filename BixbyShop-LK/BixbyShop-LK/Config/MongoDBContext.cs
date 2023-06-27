using BixbyShop_LK.Models.Comments;
using BixbyShop_LK.Models.Item;
using BixbyShop_LK.Models.Order;
using BixbyShop_LK.Users_and_Roles;
using MongoDB.Driver;

namespace BixbyShop_LK.Services
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => database.GetCollection<User>("Users");
        public IMongoCollection<Role> Roles => database.GetCollection<Role>("Roles");
        public IMongoCollection<Authority> Authorities => database.GetCollection<Authority>("Authorities");
        public IMongoCollection<Order> Orders => database.GetCollection<Order>("Orders");
        public IMongoCollection<CartAndOrder> CartAndOrders => database.GetCollection<CartAndOrder>("CartAndOrders");
        public IMongoCollection<ShopItem> ShopItems => database.GetCollection<ShopItem>("ShopItems");
        public IMongoCollection<Comment> Comments => database.GetCollection<Comment>("Comments");
    }
}
