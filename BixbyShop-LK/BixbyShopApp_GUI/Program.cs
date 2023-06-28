using BixbyShop_LK.Models.Comments.Services;
using BixbyShop_LK.Models.Item.Services;
using BixbyShop_LK.Models.Order.Services;
using BixbyShop_LK.Services;

namespace BixbyShopApp_GUI
{
    public static class Program
    {
        public static bool IsNullOrEmpty(List<string> stringList)
        {
            if (stringList == null || stringList.Count == 0)
            {
                return true;
            }

            foreach (string str in stringList)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return true;
                }
            }

            return false;
        }


        // Create instances of your services and pass the MongoDB context if needed
        public static UserService userService = new UserService();
        public static OrderService orderService = new OrderService();
        public static CartAndOrderService cartAndOrderService = new CartAndOrderService();
        public static ShopItemService shopItemService = new ShopItemService();
        public static CommentService commentService = new CommentService();

        [STAThread]
        static void Main()
        {
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
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
                Application.Run(new UserForm());
            }

        }
    }
}