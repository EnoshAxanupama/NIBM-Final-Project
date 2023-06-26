using BixbyShop_LK;
using BixbyShop_LK.Config;
using BixbyShop_LK.Services.UserService;
using BixbyShop_LK.Users_and_Roles;


namespace BixbyShopApp_GUI
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             MessageBox.Show(EnvironmentService.getEnvironmentVariable("MemDatabase"));
            //AppDbContext.in_memory = bool.Parse();
            using (var context = new AppDbContext())
            {
                
                BixbyConfig.startUp();
                

                var userDummy = context.Users.FirstOrDefault();
                var RolesDummy = context.Roles.FirstOrDefault();
                var AuthoritiesDummy = context.Authorities.FirstOrDefault();
                var OrdersDummy = context.Orders.FirstOrDefault();
                var CartAndOrdersDummy = context.CartAndOrders.FirstOrDefault();
                var ShopItemsDummy = context.ShopItems.FirstOrDefault();
                var CommentsDummy = context.Comments.FirstOrDefault();

                if(AppDbContext.in_memory)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }

                
            }


            List<Roles> userRoles = new List<Roles>();
            List<Authority> userAuthority = new List<Authority>();
            List<User> users = new List<User>();

            RoleService roleService = new RoleService();
            AuthorityService authorityService = new AuthorityService();

            if(roleService.GetRolesByRole("User") != null)
            {
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
            }


          
            ApplicationConfiguration.Initialize();
            try
            {
                string TokenValue = Properties.Settings.Default.TokenValue;
                if (!string.IsNullOrEmpty(TokenValue))
                    Application.Run(new DashBoard(TokenValue));
                else
                    Application.Run(new UserForm());

            }
            catch (Exception ex)
            {

            }
        }
    }
}