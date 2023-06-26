using System;
using System.Linq;
using System.Windows.Forms;

namespace BixbyShop_LK_GU_APP
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            try
            {
                string UserToken = Properties.Settings.Default.UserToken;
                if(string.IsNullOrEmpty(UserToken))
                    Application.Run(new UserPage());
                else
                    Application.Run(new DashBoard(UserToken));

            }
            catch (Exception ex)
            {
                Application.Run(new UserPage());
            }

        }
    }
}
