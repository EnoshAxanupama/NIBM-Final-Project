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

        // Create instances of your services and pass the MongoDB context if needed
        public static UserService userService = new UserService();
        public static OrderService orderService = new OrderService();
        public static CartAndOrderService cartAndOrderService = new CartAndOrderService();
        public static ShopItemService shopItemService = new ShopItemService();
        public static CommentService commentService = new CommentService();


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

            if (AuthorityService.GetAuthorityByName("ReadAuthority") == null
                        && AuthorityService.GetAuthorityByName("WriteAuthority") == null
                            && AuthorityService.GetAuthorityByName("UpdateAuthority") == null)
                AuthorityService.CreateAuthority(authorityList);


            Role userDefineRole = RolesService.GetRoleByNameViaList(roleInText);
            if (userDefineRole == null)
                RolesService.CreateRole(role);

            if (userDefineRole != null)
            {
                if (userDefineRole.Authorities == null)
                {
                    userDefineRole.Authorities = AuthorityService.GetAllAuthorities().ToArray();
                    RolesService.UpdateRole(userDefineRole.Id, userDefineRole);
                }
            }
            userDefineRole = RolesService.GetRoleByNameViaList(roleInText);
            if (userDefineRole != null)
            {
                rolesList.Add(userDefineRole);

                List<Authority> authorities = AuthorityService.GetAllAuthorities();
                if (authorities != null)
                {
                    authorities.ForEach(auth => {
                        if (!auth.Roles.Any())
                        {
                            auth.Roles = rolesList.ToArray();
                            AuthorityService.UpdateAuthority(auth.Id.ToString(), auth);
                        }
                    });
                }
            }
        }

        [STAThread]
        static void Main()
        {
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ApplicationConfiguration.Initialize();
           /* startUpDB("User");
            startUpDB("User");*/
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