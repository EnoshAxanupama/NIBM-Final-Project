using SendGrid.Helpers.Mail;
using SendGrid;
using System.Text.RegularExpressions;
using BixbyShop_LK.Config;
using System.Net;

namespace BixbyShop_LK.Services
{
    public class EmailService
    {
        private readonly string _apiKey;
        private readonly EnvironmentService _environmentService;
        private readonly string fromEmail;
        public EmailService()
        {
            _environmentService = new EnvironmentService();
            _apiKey = _environmentService.getEnvironmentVariable("SendGridAPIKey");
            fromEmail = _environmentService.getEnvironmentVariable("SenderEmail");
        }

        private string FormatHtml(string input, Func<string, string> valueProvider)
        {
            string formattedHtml = Regex.Replace(input, @"\{([^{}]+)\}", match =>
            {
                string placeholder = match.Groups[1].Value;
                return valueProvider(placeholder);
            }, RegexOptions.IgnoreCase);

            return formattedHtml;
        }

        private string GenerateVerificationCode(int length, String email)
        {
            length = length != null ? length : 6;

            var random = new Random();
            var verificationCode = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int digit = random.Next(0, 10);
                verificationCode += digit.ToString();
            }
            BixbyConfig.service.AddOrUpdateMapValue(email, verificationCode);
            return verificationCode;
        }

        private String emailVerificationCode(String email)
        {
            String text = "<!-- \r\nOnline HTML, CSS and JavaScript editor to run code online.\r\n-->\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n<head>\r\n  <meta charset=\"UTF-8\" />\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n  <link rel=\"stylesheet\" href=\"style.css\" />\r\n  <title>Browser</title>\r\n</head>\r\n\r\n<body>\r\n  <p style=\"text-align:center\"><span style=\"color:#ffffff\"><span style=\"font-family:Comic Sans MS,cursive\"><span style=\"font-size:72px\"><u><strong><span style=\"background-color:#2ecc71\">Welcome to BixbyShop</span></strong></u></span></span></span></p>\r\n\r\n<blockquote>\r\n<p style=\"text-align:center\"><span style=\"font-size:48px\"><span style=\"font-family:Comic Sans MS,cursive\">Your Code is : {VerificationCode}</span></span></p>\r\n\r\n<p style=\"text-align:center\"><span style=\"font-size:48px\"><span style=\"font-family:Comic Sans MS,cursive\">Please Enter our Application</span></span></p>\r\n</blockquote>\r\n\r\n</body>\r\n\r\n</html>";

            return FormatHtml(text, placeholder =>
            {
                if (placeholder == "VerificationCode")
                {
                    return GenerateVerificationCode(20, email);
                }
                else
                {
                    return string.Empty;
                }
            });

        }

        private String forgotPasswordEmailVerification(String email)
        {
            String text = "<!-- \r\nOnline HTML, CSS and JavaScript editor to run code online.\r\n-->\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n<head>\r\n  <meta charset=\"UTF-8\" />\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n  <link rel=\"stylesheet\" href=\"style.css\" />\r\n  <title>Browser</title>\r\n</head>\r\n\r\n<body>\r\n  <p style=\"text-align:center\"><strong><u><span style=\"color:#c0392b\"><span style=\"font-family:Lucida Sans Unicode,Lucida Grande,sans-serif\"><span style=\"font-size:72px\"><span style=\"background-color:#bdc3c7\">We got you Sir/Madam 😊😊</span></span></span></span></u></strong></p>\r\n\r\n<blockquote>\r\n<p style=\"text-align:center\"><span style=\"font-size:48px\"><span style=\"color:#c0392b\"><span style=\"font-family:Lucida Sans Unicode,Lucida Grande,sans-serif\">If you fogort you password that&#39;s okay here is the code {VerificationCode} to reset your password.</span></span></span></p>\r\n\r\n<p style=\"text-align:center\"><span style=\"font-size:48px\"><span style=\"color:#c0392b\"><span style=\"font-family:Lucida Sans Unicode,Lucida Grande,sans-serif\">Please enter the code in our app&nbsp;</span></span></span></p>\r\n</blockquote>\r\n</body>\r\n\r\n</html>";

            return FormatHtml(text, placeholder =>
            {
                if (placeholder == "VerificationCode")
                {
                    return GenerateVerificationCode(20, email);
                }
                else
                {
                    return string.Empty;
                }
            });

        }

       public void SendEmail(string toEmail, string subject, int i)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(fromEmail);
            var to = new EmailAddress(toEmail);
            SendGridMessage? message = null;

            if (i == 0)
                message = MailHelper.CreateSingleEmail(from, to, subject, emailVerificationCode(toEmail), emailVerificationCode(toEmail));
            else if (i == 1)
                message = MailHelper.CreateSingleEmail(from, to, subject, forgotPasswordEmailVerification(toEmail), forgotPasswordEmailVerification(toEmail));

            client.SendEmailAsync(message)
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        // Handle the error
                        Console.WriteLine(task.Exception);
                    }
                    else
                    {
                        var response = task.Result;
                        if (response.StatusCode == HttpStatusCode.Accepted)
                        {
                            Console.WriteLine("Email sent successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to send email. Status Code: {response.StatusCode}");
                        }
                    }
                });
        }

    }
}
