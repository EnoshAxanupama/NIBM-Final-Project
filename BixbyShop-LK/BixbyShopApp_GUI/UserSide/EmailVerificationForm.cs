
using BixbyShop_LK.Config;
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

        private int CallbackDelegate(string? email, string? code)
        {
            MessageBox.Show("Fuck you");

            /* BixbyShop_LK.User user = _userService.GetUserByEmail(email);
             if (user != null)
             {
                 user.EmailVerify = true;
                 bool isAck = _userService.UpdateUser(user.Id.ToString(), user);
                 if (isAck)
                 {
                     if (BixbyConfig.service.delete(user.Email))
                     {
                         MessageBox.Show("Email Verified Successfully");
                         return 1;
                     }
                     else
                         return 0;
                 }
                 else
                     return 0;
             }
             else
                 return 0;*/

            if (BixbyConfig.service.Map.ContainsKey(email))
            {
                BixbyConfig.service.Map.TryGetValue(email, out var newValue);
                if (newValue != null && !newValue.IsExpired)
                {
                    if (newValue.Value != null && newValue.Value == code)
                    {
                        MessageBox.Show("0");
                        return 0;
                    }
                    MessageBox.Show("2");

                }
                MessageBox.Show("3");
                return -1;
            }
            MessageBox.Show("4");
            return -1;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string code = textBox2.Text;

            MessageBox.Show("6");

                BixbyConfig.EmailAndAccountVerificationValidation_TakeTheAction(email, code, CallbackDelegate);

            MessageBox.Show("5");
        }
    }
}
