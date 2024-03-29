﻿using BusinessLayer.Abstract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.OptionsModel;

namespace BusinessLayer.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string ToEmail)
        {
            var smptClient = new SmtpClient();

            smptClient.Host = _emailSettings.Host;
            smptClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smptClient.UseDefaultCredentials = false;
            smptClient.Port = 587;
            smptClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smptClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(ToEmail);

            mailMessage.Subject = "Moodify| Şifre Sıfırlama Linki";
            mailMessage.Body = @$"
                <h4>Şifrenizi yenilemek için aşağıdaki linke tıklayınız.</h4>
                <p><a href='{resetPasswordEmailLink}'>şifre yenileme link</a></p>";
            mailMessage.IsBodyHtml = true;

            await smptClient.SendMailAsync(mailMessage);
        }

        public async Task SendAccountConfirmEmail(string url, string userName, string ToEmail)
        {
            var smptClient = new SmtpClient();
            MailMessage mailMessage = new()
            {
                From = new MailAddress(_emailSettings.Email),
                Subject = "Quick Quiz| Kayıt İşlemi",
                Body = @$"
                <h4><strong>{userName}</strong> kullanıcı adı ile www.quizck.com'a kayıt oldunuz, hesabı siz oluşturduysanız linke tıklayarak hesabınızı aktifleştirebilirsiniz.</h4>
                <p><a href='{url}'>Aktivasyon Linki</a></p>",
                IsBodyHtml = true
            };
            mailMessage.To.Add(ToEmail);

            await smptClient.SendMailAsync(mailMessage);
        }
    }
}
