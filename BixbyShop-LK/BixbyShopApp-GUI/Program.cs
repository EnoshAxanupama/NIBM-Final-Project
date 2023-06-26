using BixbyShop_LK;
using BixbyShop_LK.Services;
using BixbyShop_LK.Users_and_Roles;

namespace BixbyShopApp_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                var userDummy = context.Users.FirstOrDefault();
                var RolesDummy = context.Roles.FirstOrDefault();
                var AuthoritiesDummy = context.Authorities.FirstOrDefault();
                var OrdersDummy = context.Orders.FirstOrDefault();
                var CartAndOrdersDummy = context.CartAndOrders.FirstOrDefault();
                var ShopItemsDummy = context.ShopItems.FirstOrDefault();
                var CommentsDummy = context.Comments.FirstOrDefault();

                Console.WriteLine("Tables created in the in-memory database.");
            }

            UserService.RoleService roleService = new UserService.RoleService();
            UserService.AuthorityService authorityService = new UserService.AuthorityService();

            List<Roles> userRoles = new List<Roles>();
            List<Authority> userAuthority = new List<Authority>();
            List<User> users = new List<User>();


            Roles roles = new Roles();
            roles.Authorities = userAuthority;
            roles.Users = users;
            roles.Role = "User";
            roleService.CreateRoles(roles);
            
            // ===================================================
            Authority ReadAuthority = authorityService.saveOneAuthorityAction("ReadAuthority", userRoles);
            Authority WriteAuthority = authorityService.saveOneAuthorityAction("WriteAuthority", userRoles);
            Authority UpdateAuthority = authorityService.saveOneAuthorityAction("UpdateAuthority", userRoles);
           
            // ===================================================

            Roles role = roleService.GetRoles("User");
            userAuthority.Add(ReadAuthority);
            userAuthority.Add(WriteAuthority);
            userAuthority.Add(UpdateAuthority);

            role.Authorities = userAuthority;
            roleService.UpdateRoles(role);


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}