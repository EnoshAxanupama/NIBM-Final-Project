using BixbyShop_LK.Users_and_Roles;
using System.Data;

namespace BixbyShop_LK.Services.UserService
{
    public class RoleService
    {

        private readonly AppDbContext _context;

        public RoleService()
        {
            _context = new AppDbContext();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Roles GetRoles(string roles) => _context.Roles.Where(r => r.Role == roles).FirstOrDefault();

        public int saveASingleRole(string role, ICollection<User> users, ICollection<Authority> authorities)
        {
            if (_context.Roles.Where(r => r.Role == role) == null)
            {
                var newRole = new Roles { Role = role, Authorities = authorities, Users = users };
                _context.Roles.Add(newRole);
                return _context.SaveChanges();
            }
            return -1;
        }
        public List<Roles> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Roles GetRolesByRole(string role)
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
}
