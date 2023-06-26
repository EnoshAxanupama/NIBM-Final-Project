using BixbyShop_LK.Users_and_Roles;
using System.Data;

namespace BixbyShop_LK.Services.UserService
{
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

        public Authority GetAuthority(string authority) => _context.Authorities.Where(a => a.Name == authority).FirstOrDefault();

        public Authority saveOneAuthorityAction(string name, ICollection<Roles>? roles)
        {
            if (GetAuthorityByName(name) == null)
            {
                Authority authority = new Authority
                {
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
