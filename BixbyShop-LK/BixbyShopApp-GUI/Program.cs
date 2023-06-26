using BixbyShop_LK;

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
                ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}