using BixbyShop_LK.Models.Comments.Services;
using BixbyShop_LK.Models.Item.Services;
using BixbyShop_LK.Models.Order.Services;
using BixbyShop_LK.Services;
using BixbyShop_LK.Users_and_Roles;
using ServiceBase.Extensions;

namespace BixbyShopApp_GUI
{
    internal static class Program
    {

        public static MongoDbContext mongoDbContext = new MongoDbContext("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256", "NIBM");

        // Create instances of your services and pass the MongoDB context if needed
        public static UserService userService = new UserService(mongoDbContext);
        public static RolesService rolesService = new RolesService(mongoDbContext);
        public static AuthorityService authorityService = new AuthorityService(mongoDbContext);
        public static OrderService orderService = new OrderService(mongoDbContext);
        public static CartAndOrderService cartAndOrderService = new CartAndOrderService(mongoDbContext);
        public static ShopItemService shopItemService = new ShopItemService(mongoDbContext);
        public static CommentService commentService = new CommentService(mongoDbContext);


        private static void startUpDB(String roleInText)
        {
         
            List<Role> rolesList = new List<Role>();
            List<Authority> authorityList = new List<Authority>();

            Role role = new Role
            {
                UserRole = roleInText
            };

            Authority ReadAuthority = new Authority { Name = "ReadAuthority", Roles = rolesList.ToArray() };
            Authority WriteAuthority = new Authority { Name = "WriteAuthority", Roles = rolesList.ToArray() };
            Authority UpdateAuthority = new Authority { Name = "UpdateAuthority", Roles = rolesList.ToArray() };

            authorityList.Add(ReadAuthority);
            authorityList.Add(WriteAuthority);
            authorityList.Add(UpdateAuthority);

            if (authorityService.GetAuthorityByName("ReadAuthority") == null
                        && authorityService.GetAuthorityByName("WriteAuthority") == null
                            && authorityService.GetAuthorityByName("UpdateAuthority") == null)
                authorityService.CreateAuthority(authorityList);


            Role userDefineRole = rolesService.GetRoleByRole(roleInText);
            if (userDefineRole == null)
                rolesService.CreateRole(role);

            if (userDefineRole != null)
            {
                if (userDefineRole.Authorities == null)
                {
                    userDefineRole.Authorities = authorityService.GetAllAuthorities().ToArray();
                    rolesService.UpdateRole(userDefineRole.Id, userDefineRole);
                }
            }
            userDefineRole = rolesService.GetRoleByRole(roleInText);
            if (userDefineRole != null)
            {
                rolesList.Add(userDefineRole);

                List<Authority> authorities = authorityService.GetAllAuthorities();
                if (authorities != null)
                {
                    authorities.ForEach(auth => {
                        if (!auth.Roles.Any())
                        {
                            auth.Roles = rolesList.ToArray();
                            authorityService.UpdateAuthority(auth.Id.ToString(), auth);
                        }
                    });
                }
            }
        }

        [STAThread]
        static void Main()
        {
            /*try
            {
                userService = new UserService(mongoDbContext);
            }
            catch(Exception e)
            {
                try
                {
                    userService = new UserService("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256", "NIBM");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stack OverFall Error");

                }

            }
*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ApplicationConfiguration.Initialize();
            startUpDB("User");
            startUpDB("User");
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
                Application.Run(new UserForm());
            }

        }
    }
}