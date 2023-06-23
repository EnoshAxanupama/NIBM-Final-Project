using BixbyShop_LK.Config;
using BixbyShop_LK.Users_and_Roles;
using BCryptNet = BCrypt.Net.BCrypt;

namespace BixbyShop_LK.Services
{
    public class UserService
    {

        private readonly AppDbContext _context;
        private readonly RoleService _roleService;
        private readonly TokenService _tokenService;

        public UserService()
        {
            _context = new AppDbContext();
            _roleService = new RoleService();
            _tokenService = new TokenService();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        // **************************************************************************************************
        // **************************************************************************************************
        // **************************************************************************************************
        // **************************************************************************************************
        // **************************************************************************************************
        // **************************************************************************************************
        // **************************************************************************************************

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

        public String signUp(String fistName, String lastName, String email, String address, String password, String pic, List<String> roles)
        {
            if(checkAndGetUser(email, false))
            {
                if(saveAUser(fistName, lastName, email, address, password, pic, roles) != -1)
                {
                    return _tokenService.tokenCreator(email, BCryptNet.HashPassword(password));
                }
            }
            return null;
        }

        public String login(String email, String password)
        {
            User user = checkAndGetUser(email, true);
            if (user != null)
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


        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================
        // ===========================================================================================================

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
                User user = new User { FirstName = fistName, LastName = lastName, Email = email, Address = address, Pic = pic };
                user.Password = BCryptNet.HashPassword(password);

                Roles[] userRoles = { };
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
    
        }

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

            public int saveOneAuthorityAction(String name, ICollection<Roles> roles)
            {
                if(_context.Authorities.Find(name) == null)
                {
                    Authority authority = new Authority();
                    authority.Name = name;
                    authority.Roles = roles;

                    _context.Authorities.Add(authority);

                    return _context.SaveChanges();
                }
                return -1;
            }
        }

    }
}
