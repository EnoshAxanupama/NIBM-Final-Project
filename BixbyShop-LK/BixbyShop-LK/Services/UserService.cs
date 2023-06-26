using BixbyShop_LK.Config;
using BixbyShop_LK.Config.DI;
using BixbyShop_LK.Users_and_Roles;
using System.Data;
using BCryptNet = BCrypt.Net.BCrypt;

namespace BixbyShop_LK.Services
{
    [Component]
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
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int ResetThePassword(String oldPassword,String password, String email)
        {
            User user = checkAndGetUser(email, true);
            if (user.Password == BCryptNet.HashPassword(oldPassword))
            {
                user.Password = BCryptNet.HashPassword(password);
                return UpdateUser(user);
            }
            return -1;
        }

        public int EmailActionInUser(String? password, String? email, String code, int i)
        {
            if(i == 0)
                return _bixbyConfig.EmailVerificationValidation_TakeTheAction(password, email, code, ResetThePasswordViaEmail);
            else if (i == 1)
                return _bixbyConfig.EmailVerificationValidation_TakeTheAction(password, email, code, ResetThePasswordViaEmail);
            else
                return -1;
        }

        private int ResetThePasswordViaEmail(String? password, String? email)
        {
            User user = checkAndGetUser(email, true);
            user.Password = BCryptNet.HashPassword(password);
            return UpdateUser(user);
        }

        private int EmailVerifyViaEmail(String? password, String? email)
        {
            User user = checkAndGetUser(email, true);
            user.EmailVerify = true;
            return UpdateUser(user);
        }

        public dynamic checkAndGetUser(String email, bool getFullUser)
        {
            User user = _context.Users.Where(user => user.Email == email).FirstOrDefault();
            if (getFullUser)
                return user;
            else
            {
                if (user != null)
                    return true;
                else
                    return false;
            }
        }

        public int requestPasswordReset(String email)
        {
            User user = checkAndGetUser(email, true);
            if(user != null)
            {
                _emailService.SendEmail(email, "Reset Tour Password 😊✌️✌️💥", 0);
                return 0;
            }
            return -1;
        }

        public String signUp(String fistName, String lastName, String email, String address, String password, String pic, List<String> roles)
        {
            if(checkAndGetUser(email, false))
            {
                if(saveAUser(fistName, lastName, email, address, password, pic, roles) != -1)
                {
                     _emailService.SendEmail(email, "VerifyYourEmail 😊✌️✌️💥", 0);
                    return _tokenService.tokenCreator(email, BCryptNet.HashPassword(password));
                }
            }
            return null;
        }

        public String login(String email, String password)
        {
            User user = checkAndGetUser(email, true);
            if (user != null && user.EmailVerify)
                if (passwordMatch(password, user))
                    return _tokenService.tokenCreator(email, BCryptNet.HashPassword(password));
                else
                    return null;
            else
                return null;
        }

        public bool checkUserAuthMiddleWare(String token)
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

        private bool passwordMatch(String plainPassword, User user)
        {
            return BCryptNet.Verify(plainPassword, user.Password);
        }

        private int saveAUser(String fistName, String lastName, String email, String address, String password, String pic, List<String> roles)
        {
            if(checkAndGetUser(email, false))
                return -1;
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
                        userRoles[i] = role;
                    }
                }
                user.Roles = userRoles;

                _context.Users.Add(user);

                return _context.SaveChanges();
            }
        }

        [Component]
        public class RoleService {

            private readonly AppDbContext _context;

            public RoleService()
            {
                _context = new AppDbContext();
            }
            public void Dispose()
            {
                _context.Dispose();
            }

            public Roles GetRoles(String roles) => _context.Roles.Where(r => r.Role == roles).FirstOrDefault();

            public int saveASingleRole(String role, ICollection<User> users, ICollection<Authority> authorities)
            {
                if(_context.Roles.Where(r => r.Role == role) == null)
                {
                    var newRole = new Roles { Role = role , Authorities = authorities, Users = users};
                    _context.Roles.Add(newRole);
                    return _context.SaveChanges();
                }
                return -1;
            }
            public List<Roles> GetAllRoles()
            {
                return _context.Roles.ToList();
            }

            public Roles GetRolesById(string role)
            {
                return _context.Roles.FirstOrDefault(r => r.Role == role);
            }

            public void CreateRoles(Roles roles)
            {
                _context.Roles.Add(roles);
                _context.SaveChanges();
            }

            public void UpdateRoles(Roles role)
            {
                _context.Roles.Update(role);
                _context.SaveChanges();
            }

            public void DeleteRoles(Roles roles)
            {
                _context.Roles.Remove(roles);
                _context.SaveChanges();
            }

        }

        [Component]
        public class AuthorityService
        {
            private readonly AppDbContext _context;

            public AuthorityService()
            {
                _context = new AppDbContext();
            }
            public void Dispose()
            {
                _context.Dispose();
            }

            public Authority GetAuthority(String authority) => _context.Authorities.Where(a=> a.Name == authority).FirstOrDefault();

            public Authority saveOneAuthorityAction(String name, ICollection<Roles>? roles)
            {
                if(GetAuthorityByName(name) == null)
                {
                    Authority authority = new Authority { 
                        Name = name,
                        Roles = roles
                    };

                    _context.Authorities.Add(authority);

                    _context.SaveChanges();

                    return GetAuthorityByName(name);
                }
                return null;
            }

            public List<Authority> GetAllAuthorities()
            {
                return _context.Authorities.ToList();
            }

            public Authority GetAuthorityByName(string name)
            {
                return _context.Authorities.FirstOrDefault(a => a.Name == name);
            }

            public void CreateAuthority(Authority authority)
            {
                _context.Authorities.Add(authority);
                _context.SaveChanges();
            }

            public void UpdateAuthority(Authority authority)
            {
                _context.Authorities.Update(authority);
                _context.SaveChanges();
            }

            public void DeleteAuthority(Authority authority)
            {
                _context.Authorities.Remove(authority);
                _context.SaveChanges();
            }
        }

    }
}
