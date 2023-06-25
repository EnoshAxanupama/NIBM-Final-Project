using BixbyShop_LK.Config.DI;
using BixbyShop_LK.Users_and_Roles;

namespace BixbyShop_LK.Services
{
    [Component]
    public class AuthorityService
    {
        private readonly AppDbContext _dbContext;

        public AuthorityService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Authority> GetAllAuthorities()
        {
            return _dbContext.Authorities.ToList();
        }

        public Authority GetAuthorityByName(string name)
        {
            return _dbContext.Authorities.FirstOrDefault(a => a.Name == name);
        }

        public void CreateAuthority(Authority authority)
        {
            _dbContext.Authorities.Add(authority);
            _dbContext.SaveChanges();
        }

        public void UpdateAuthority(Authority authority)
        {
            _dbContext.Authorities.Update(authority);
            _dbContext.SaveChanges();
        }

        public void DeleteAuthority(Authority authority)
        {
            _dbContext.Authorities.Remove(authority);
            _dbContext.SaveChanges();
        }
    }
}
