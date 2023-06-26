using BixbyShop_LK.Config;
using BixbyShop_LK.Users_and_Roles;
using System.Data;
using BCryptNet = BCrypt.Net.BCrypt;

namespace BixbyShop_LK.Services.UserService
{
    public class UserService
    {

        private readonly AppDbContext _context;
        private readonly RoleService _roleService;
        private readonly TokenService _tokenService;
        private readonly BixbyConfig _bixbyConfig;
        private readonly EmailService _emailService;

        public UserService()
        {
            _context = new AppDbContext();
            _roleService = new RoleService();
            _tokenService = new TokenService();
            _bixbyConfig = new BixbyConfig();
            _emailService = new EmailService();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int ResetThePassword(string oldPassword, string password, string email)
        {
            User user = GetUser(email);
            if (user.Password == BCryptNet.HashPassword(oldPassword))
            {
                user.Password = BCryptNet.HashPassword(password);
                return UpdateUser(user);
            }
            return -1;
        }

        public int EmailActionInUser(string? password, string? email, string code, int i)
        {
            if (i == 0)
                return _bixbyConfig.EmailVerificationValidation_TakeTheAction(password, email, code, ResetThePasswordViaEmail);
            else if (i == 1)
                return _bixbyConfig.EmailVerificationValidation_TakeTheAction(password, email, code, ResetThePasswordViaEmail);
            else
                return -1;
        }

        private int ResetThePasswordViaEmail(string? password, string? email)
        {
            User user = GetUser(email);
            user.Password = BCryptNet.HashPassword(password);
            return UpdateUser(user);
        }

        private int EmailVerifyViaEmail(string? password, string? email)
        {
            User user = GetUser(email);
            user.EmailVerify = true;
            return UpdateUser(user);
        }

        public User GetUser(string email)
        {
            return _context.Users.Where(user => user.Email == email).FirstOrDefault();
        }

        public int requestPasswordReset(string email)
        {
            User user = GetUser(email);
            if (user != null)
            {
                _emailService.SendEmail(email, "Reset Tour Password 😊✌️✌️💥", 0);
                return 0;
            }
            return -1;
        }

        public string signUp(string email, string password, List<string>? roles)
        {
            if (GetUser(email) == null)
            {
                User user = saveAUser("", "", email, "", password, "default.png", roles);
                if (user != null)
                {
                    _emailService.SendEmail(user.Email, "VerifyYourEmail 😊✌️✌️💥", 0);
                    return _tokenService.tokenCreator(user.Email, BCryptNet.HashPassword(password));
                }
            }
            return null;
        }

        public string login(string email, string password)
        {
            User user = GetUser(email);
            if (user != null && user.EmailVerify)
                if (passwordMatch(password, user))
                    return _tokenService.tokenCreator(email, BCryptNet.HashPassword(password));
                else
                    return null;
            else
                return null;
        }

        public bool checkUserAuthMiddleWare(string token)
        {
            return _tokenService.ValidateJwtToken(token);
        }

        public int UpdateUser(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private bool passwordMatch(string plainPassword, User user)
        {
            return BCryptNet.Verify(plainPassword, user.Password);
        }

        private User saveAUser(string fistName, string lastName, string email, string address, string password, string pic, List<string> roles)
        {
            if (GetUser(email) != null)
                return null;
            else
            {
                User user = new User { FirstName = fistName, LastName = lastName, Email = email, Address = address, Pic = pic, EmailVerify = false };
                user.Password = BCryptNet.HashPassword(password);

                List<Roles> userRoles = new List<Roles>();
                for (int i = 0; i < roles.Count; i++)
                {
                    Roles role = _roleService.GetRoles(roles[i]);
                    if (role != null)
                    {
                        userRoles.Add(role);
                    }
                }
                user.Roles = userRoles;

                _context.Users.Add(user);
                _context.SaveChanges();

                return GetUser(user.Email);
            }
        }
    }
}
