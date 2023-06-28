using BixbyShop_LK.Services;
using BCryptNet = BCrypt.Net.BCrypt;

namespace BixbyShopApp_GUI.UserSide
{
    public partial class PasswordResetTokenVerificationForm : MetroFramework.Forms.MetroForm
    {
        private readonly UserService _userService;

        public PasswordResetTokenVerificationForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void PasswordResetTokenVerificationForm_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;
            String code = textBox2.Text;
            String password = textBox3.Text;
            String con_password = textBox4.Text;

            string[] elements = { email, code, password, con_password };
            List<String> List = new List<String>();
            List.AddRange(elements);

            if (Program.IsNullOrEmpty(List))
            {
                BixbyShop_LK.User user = _userService.GetUserByEmail(email);
                if (user != null)
                {
                    bool IsTokenExpired = user.IsTokenExpired(code);
                    if (IsTokenExpired == false)
                    {
                        if (string.Equals(password, con_password))
                        {
                            user.Tokens[code].valid = false;
                            user.Password = BCryptNet.HashPassword(password);
                            if (_userService.UpdateUser(user.Id, user) == true)
                            {
                                MessageBox.Show("Good to go now");
                                UserForm.tokenSaver("");
                            }
                            else
                                MessageBox.Show("Opps !!!");
                        }
                        else
                            MessageBox.Show("Password MissMatch");
                       
                    }
                }
            }

        }
    }
}
