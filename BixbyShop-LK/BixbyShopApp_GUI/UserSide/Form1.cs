using BixbyShop_LK.Services;
using MetroFramework.Forms;
using SendGrid;
using MimeKit;
using System.Text.RegularExpressions;
using BixbyShopApp_GUI.UserSide;
using MailKit.Security;

namespace BixbyShopApp_GUI
{
    public partial class UserForm : MetroForm
    {
        private void tokenSaver(String token)
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
        private PictureBox pb1;
        private PictureBox pb2;
        public UserForm()
        {
            InitializeComponent();

            pb1 = new PictureBox();
            metroPanel1.Controls.Add(pb1);
            pb1.Dock = DockStyle.Fill;

            pb2 = new PictureBox();
            metroPanel2.Controls.Add(pb2);
            pb2.Dock = DockStyle.Fill;
        }

        private void Blur()
        {
            Bitmap bmp = Screenshot.TakeSnapshot(metroPanel1);
            Bitmap bmp1 = Screenshot.TakeSnapshot(metroPanel2);
            BitmapFilter.GaussianBlur(bmp, 0);
            BitmapFilter.GaussianBlur(bmp1, 0);

            pb1.Image = bmp;
            pb1.BringToFront();

            pb2.Image = bmp1;
            pb2.BringToFront();
        }

        private void UnBlur()
        {
            pb1.Image = null;
            pb1.SendToBack();

            pb2.Image = null;
            pb2.SendToBack();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
           
        }

        private void Login_Click(object sender, EventArgs e)
        {

            String userName = email.Text.Trim();
            String userPassword = password.Text.Trim();
            if (userName == null || userPassword == null)
            {
                Blur();
                MessageBox.Show("You Miss somethings look back again !! 😑😮🤐😶‍🌫️😐🤨😑");
                UnBlur();
            }
            String token = Program.userService.Login(userName, userPassword);
            if (token != null)
            {
                tokenSaver(token);
                Blur();
                new CustomMessageBox(token).ShowDialog();
                UnBlur();
            }
            else
            {
                Blur();
                MessageBox.Show("Try Again !! ");
                UnBlur();
            }

        }

        private void NewAccount_Click(object sender, EventArgs e)
        {
            String email = c_email.Text;
            String password = c_pass.Text;
            String conPass = c_con_pass.Text;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(conPass))
            {
                bool isValidEmail = EmailServiceHelper.ValidateEmailPattern(email) && !EmailServiceHelper.ValidateEmailUsing_Zerobounce(email);
                if (!isValidEmail)
                {
                    Blur();
                    MessageBox.Show("Email Not Valid according to our Regex Patterns or We check online but I did not working Sorry ! 😣😣😣");
                    UnBlur();
                }
                else
                {
                    if (string.Equals(password, conPass))
                    {
                        String token = Program.userService.CreateNewAccount(email, password, conPass);
                        Blur();
                        if (token != null)
                        {

                            new CustomMessageBox(token).ShowDialog();
                            tokenSaver(token);

                            IEmailService emailService = new EmailServiceHelper();
                            EmailService._emailServiceHelper = emailService;
                            EmailService.SendEmail(email, "Email Verification Code for Your Account 🙂🙂", 0);
                            UnBlur();
                        }
                        else
                        {
                            MessageBox.Show($"{email} user already exists.");
                            UnBlur();
                        }
                           
                    }
                }


            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            Blur();
            new EmailVerificationForm().Show();
            UnBlur();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            Blur();
            new PasswordResetTokenVerificationForm().Show();
            UnBlur();
        }
    }
    public class EmailServiceHelper : IEmailService
    {
        public static bool ValidateEmailUsing_Zerobounce(string email)
        {
            string apiKey = "Y54EU1YFR+lhBHiNSVJITj05oG5LiSvCNpTOd10NiSbiSBEMNc7MzPds/mh216IAdz2jPEBbALGBV2QY4isjwA==";
            apiKey = EncryptionHelper.Decrypt(apiKey);
            string apiUrl = $"https://api.zerobounce.net/v2/validate?api_key={apiKey}&email={email}";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(apiUrl).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    // Parse the JSON response to check the email validity status
                    // You may need to adjust this code based on the ZeroBounce API response structure
                    bool isValid = jsonResponse.Contains("\"status\":\"valid\"");
                    return isValid;
                }
            }

            return false; // Error occurred or API request failed
        }
        public static bool ValidateEmailPattern(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);
            return match.Success;
        }
        public static bool ValidateEmail(string email)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Sender", EncryptionHelper.Decrypt("t2rtBrY8JzecZNhvbApQW/q8+ANhkWK+eOTwhDdma2n6N43+8rKtCEV3eHtphgpj")));
                message.To.Add(new MailboxAddress("Recipient", email));
                message.Subject = "Email Address Verification";
                message.Body = new TextPart("plain")
                {
                    Text = "This is a just verification email."
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);

                    // Note: Provide your SendGrid API key as the first parameter and an empty string as the second parameter.
                    client.Authenticate("your-sendgrid-api-key", "");

                    client.Send(message);
                    client.Disconnect(true); ;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
                return false;
            }
        }
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
