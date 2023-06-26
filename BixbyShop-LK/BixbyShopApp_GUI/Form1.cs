using BixbyShop_LK.Services.UserService;


namespace BixbyShopApp_GUI
{
    public partial class UserForm : MetroFramework.Forms.MetroForm
    {
        private readonly UserService userService = new UserService();

        public UserForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Login_Click(object sender, EventArgs e)
        {
            String email = email_txt.Text;
            String password = password_txt.Text;

            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
            {
                String token = userService.login(email, password);
                Properties.Settings.Default.TokenValue = token;
                Properties.Settings.Default.Save();

                new DashBoard(token).Show();

            }
            else
                MessageBox.Show("UserName or Password were incorrect. Please Try again !! 😑😣😣");
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            String email = email_txt.Text;
            String password = password_txt.Text;
            String conPass = sign_up_con_pass.Text;

            List<String> list = new List<String>();
            list.Add("User");
            String token = userService.signUp(email, password, list);
            MessageBox.Show(token);
            Properties.Settings.Default.TokenValue = token;
            Properties.Settings.Default.Save();

            /*if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(conPass))
            {
                if (string.Equals(password, conPass))
                {
                    

                    new DashBoard(token).Show();
                    this.Close();
                }
            }*/
        }
    }
}