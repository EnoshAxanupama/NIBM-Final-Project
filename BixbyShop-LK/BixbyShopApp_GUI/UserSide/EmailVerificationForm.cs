using BixbyShop_LK.Services;
using Microsoft.IdentityModel.Tokens;

namespace BixbyShopApp_GUI.UserSide
{
    public partial class EmailVerificationForm : MetroFramework.Forms.MetroForm
    {
        private readonly UserService _userService;

        public EmailVerificationForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void EmailVerificationForm_Load(object sender, EventArgs e)
        {
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string code = textBox2.Text;

            List<String> List = new List<String>();
            List.Add(email);
            List.Add(code);

            if (Program.IsNullOrEmpty(List))
            {
                BixbyShop_LK.User user = _userService.GetUserByEmail(email);
                if (user != null)
                {
                    bool IsTokenExpired = user.IsTokenExpired(code);
                    if (IsTokenExpired == false)
                    {
                        user.EmailVerify = true;
                        user.Tokens[code].valid = false;
                        if (_userService.UpdateUser(user.Id, user) == true)
                            MessageBox.Show("Good to go now");
                        else
                            MessageBox.Show("Opps !!!");
                    }
                }
            }
        }
    }
}
