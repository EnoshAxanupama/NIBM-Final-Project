using BCryptNet = BCrypt.Net.BCrypt;
using MongoDB.Bson;
using MongoDB.Driver;
using BixbyShop_LK.Users_and_Roles;

namespace BixbyShop_LK.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> userCollection;
        private readonly EmailService _emailService;
        private readonly TokenService _tokenService;
        private readonly RolesService _rolesService;
        private readonly IMongoDatabase database;

        public UserService(MongoDbContext mongoDbContext)
        {
            userCollection = mongoDbContext.Users;
            _tokenService = new TokenService(mongoDbContext);
            _emailService = new EmailService();
            _rolesService = new RolesService(mongoDbContext);
        }

        public UserService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
            userCollection = database.GetCollection<User>("Users");

            _tokenService = new TokenService(connectionString,databaseName);
            _emailService = new EmailService();
            _rolesService = new RolesService(connectionString, databaseName);
        }

        public List<User> GetAllUsers()
        {
            return userCollection.Find(_ => true).ToList();
        }

        public string CreateNewAccount(string username, string password, string co_password)
        {
            User existingUser = GetUserByEmail(username);
            if (existingUser == null)
            {
                Role role = _rolesService.GetRoleByRole("User");
                if (role == null)
                {
                    return "Role not found. Unable to create account.";
                }

                string hashedPassword = BCryptNet.HashPassword(password);
                List<Role> rolesList = new List<Role> { role };
                User newUser = new User { Email = username, Password = hashedPassword, Roles = rolesList.ToArray() };
                CreateUser(newUser);

                User createdUser = GetUserByEmail(username);
                if (createdUser == null)
                {
                    return "Account was not created due to an error.";
                }

                return _tokenService.tokenCreator(createdUser.Email, createdUser.Password);
            }
            else
            {
                return $"{existingUser.Email} user already exists.";
            }
        }

        public string Login(string username, string password)
        {
            User user = GetUserByEmail(username);
            if (user != null && BCryptNet.Verify(password, user.Password))
            {
                return _tokenService.tokenCreator(user.Email, user.Password);
            }

            return null;
        }

        public User GetUserByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            return userCollection.Find(filter).FirstOrDefault();
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
