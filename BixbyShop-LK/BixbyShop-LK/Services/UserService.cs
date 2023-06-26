using BixbyShop_LK.Config;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> userCollection;
        private readonly MongoDBContext mongoDBContext;
        public UserService(IMongoDatabase database)
        {
            userCollection = database.GetCollection<User>("users");
        }
        public UserService(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
            userCollection = mongoDBContext.Users;
        }
        public List<User> GetAllUsers()
        {
            return userCollection.Find(_ => true).ToList();
        }

        public User GetUserById(string userId)
        {
            var objectId = new ObjectId(userId);
            return userCollection.Find(user => user.Id == objectId).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            userCollection.InsertOne(user);
        }

        public void UpdateUser(string userId, User updatedUser)
        {
            var objectId = new ObjectId(userId);
            userCollection.ReplaceOne(user => user.Id == objectId, updatedUser);
        }

        public void DeleteUser(string userId)
        {
            var objectId = new ObjectId(userId);
            userCollection.DeleteOne(user => user.Id == objectId);
        }
    }
}
