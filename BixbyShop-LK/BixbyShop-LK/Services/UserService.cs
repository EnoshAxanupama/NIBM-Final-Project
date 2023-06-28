using BCryptNet = BCrypt.Net.BCrypt;
using MongoDB.Bson;
using MongoDB.Driver;
using SendGrid;

namespace BixbyShop_LK.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> userCollection;

        public UserService()
        {
            var client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
            var database = client.GetDatabase("BixbyShop_LK");
            userCollection = database.GetCollection<User>("Users");
        }

        public List<User> GetAllUsers()
        {

            return userCollection.Find(_ => true).ToList();
        }

        public static dynamic GetUserBasedOnToken(String user, bool allowBoolean) {
            return TokenService.ValidateJwtToken(user, allowBoolean);
        }

        public string CreateNewAccount(string username, string password, string co_password)
        {
            User existingUser = GetUserByEmail(username);
            if (existingUser == null)
            {
                User newUser = new User();
                newUser.Email = username;
                newUser.Password = BCryptNet.HashPassword(password);
                newUser.Tokens = new Dictionary<string, VerficationCode>();
                CreateUser(newUser);

                User createdUser = GetUserByEmail(username);
                if (createdUser == null)
                {
                    return null;
                }
                return TokenService.tokenCreator(createdUser.Email, createdUser.Password);
            }
            else
            {
                return null;
            }
        }
        public string Login(string username, string password)
        {
            User user = GetUserByEmail(username);
            if (user != null && BCryptNet.Verify(password, user.Password))
            {
                return TokenService.tokenCreator(user.Email, user.Password);
            }

            return null;
        }

        public User GetUserByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            return userCollection.Find(filter).FirstOrDefault();
        }

        public User GetUserById(ObjectId userId)
        {
            return userCollection.Find(user => user.Id == userId).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            userCollection.InsertOne(user);
        }

        public bool UpdateUser(ObjectId userId, User updatedUser)
        {
            return userCollection.ReplaceOne(user => user.Id == userId, updatedUser).IsAcknowledged;
        }

        public void DeleteUser(ObjectId userId)
        {
            userCollection.DeleteOne(user => user.Id == userId);
        }
    }
}