using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace PD421_MVC_Shop.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string host = "smtp.gmail.com";
            int port = 587;
            string emailAddress = "dmytro.potapchuk22@gmail.com";
            string password = "cyje ixsm kufb hijr";

            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(emailAddress, password);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(emailAddress);
            message.To.Add(email);
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            await smtpClient.SendMailAsync(message);
        }
    }
}
