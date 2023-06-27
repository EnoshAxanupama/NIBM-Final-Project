using BixbyShop_LK.Config;
using BixbyShop_LK.Services;
using BixbyShop_LK.Users_and_Roles;
using BixbyShop_LK.Users_and_Roles.Services;
using ServiceBase.Extensions;

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
            {
                MongoDBContext mongoDBContext = new MongoDBContext("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256", "NIBM");

                var rolesService = new RolesService(mongoDBContext);
                var authorityService = new AuthorityService(mongoDBContext);

                List<Roles> rolesList = new List<Roles>();
                List<Authority> authorityList = new List<Authority>();

                Roles role = new Roles
                {
                    Role = "User"
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


                Roles userRole = rolesService.GetAllRoles().Find(role => role.Role == "User");
                if (userRole == null)
                    rolesService.CreateRole(role);

                if (userRole != null)
                {
                    if (userRole.Authorities == null)
                    {
                        userRole.Authorities = authorityService.GetAllAuthorities().ToArray();
                        rolesService.UpdateRole(userRole.Id, userRole);
                    }
                }
                userRole = rolesService.GetAllRoles().Find(role => role.Role == "User");
                if (userRole != null)
                {
                    rolesList.Add(userRole);

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



            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}