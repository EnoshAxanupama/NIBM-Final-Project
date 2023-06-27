using BixbyShop_LK.Services;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using SendGrid;

namespace BixbyShopApp_GUI
{
    public partial class UserForm : MetroForm
    {
        private MetroStyleManager metroStyleManager;
        private void tokenSever(String token)
        {
            try
            {
                Properties.Settings.Default.TokenValue = token;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {

            }
        }

        public UserForm()
        {
            InitializeComponent();
            InitializeMetroStyleManager();
            RefreshTheme();
            metroToggle1.Checked = true;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            InitializeMetroStyleManager();
            RefreshTheme();
            metroToggle1.Checked = true;
        }

        private void InitializeMetroStyleManager()
        {
            metroStyleManager = new MetroStyleManager();
            metroStyleManager.Owner = this;
            metroStyleManager.Theme = MetroThemeStyle.Dark;

            // Associate the metroToggle1 with the metroStyleManager
            metroStyleManager.Style = MetroColorStyle.Blue;
            metroStyleManager.Theme = MetroThemeStyle.Dark;
            metroToggle1.StyleManager = metroStyleManager;

            metroToggle1.CheckedChanged += metroToggle1_CheckedChanged;
            RefreshTheme();
        }

        private void RefreshTheme()
        {
            Refresh();
            foreach (Control control in Controls)
            {
                if (control is MetroFramework.Controls.MetroLabel ||
                    control is MetroFramework.Controls.MetroButton ||
                    control is MetroFramework.Controls.MetroTextBox)
                {
                    metroStyleManager.Theme = metroToggle1.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
                    control.Refresh();
                }
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            metroStyleManager.Theme = metroToggle1.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            RefreshTheme();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            String userName = email.Text.Trim();
            String userPassword = password.Text.Trim();
            String token = Program.userService.Login(userName, userPassword);
            tokenSever(token);
            new CustomMessageBox(token).ShowDialog();
        }

        private void NewAccount_Click(object sender, EventArgs e)
        {
            String email = c_email.Text;
            String password = c_pass.Text;
            String conPass = c_con_pass.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(conPass))
            {
                if (string.Equals(password, conPass))
                {
                    String token = Program.userService.CreateNewAccount(email, password, conPass);
                    new CustomMessageBox(token).ShowDialog();
                    tokenSever(token);

                    IEmailService emailService = new EmailServiceHelper();
                    EmailService._emailServiceHelper = emailService;
                    EmailService.SendEmail(email, "Email Verification Code for Your Account 🙂🙂", 0);
                }
            }
        }
    }
    public class EmailServiceHelper : IEmailService
    {
        public void SendEmail(Response response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                MessageBox.Show("Email sent successfully!");
            }
            else
            {
                MessageBox.Show($"Failed to send email. Status code: {response.StatusCode}");
            }
        }
    }
}
