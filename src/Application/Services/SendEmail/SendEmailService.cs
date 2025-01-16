using Domain.Interfaces.Service;
using Domain.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;


namespace Application.Services.SendEmail
{
    public class SendEmailService : ISendEmailService
    {
        private readonly EmailSettings _mailSettings;
        public SendEmailService(IOptions<EmailSettings> emailSettings)
        {
            _mailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest mailRequest)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(_mailSettings.Mail!, _mailSettings.DisplayName);
            message.To.Add(new MailAddress(mailRequest.ToEmail!));
            message.Subject = mailRequest.Subject;

            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }

            message.IsBodyHtml = true;
            message.Body = mailRequest.Body;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host!;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

        public string CarregaCorpoEmail(string mensagem)
        {
            var body = Estilo();

            body += "<div style='text-align: center'><img style='width: 109px !important;  border-radius: 25px !important;' src=\"https://palpitecerto.net.br/assets/img/logo_fundo_azul.png\" class=\"mb-2\"></div>";
            body += "<div style='text-align: center; color: rgb(3, 40, 248); font-size: 24px;text-shadow: -1px 1px 0px green'>PalpiteCerto</div>";
            body += $"<div>{mensagem}</div>";
            body += "<div style='text-align: center'></div>";


            return body;
        }

        private string Estilo()
        {
            return @"<style>img { width: 109px !important;  border-radius: 25px !important;}</style>";
        }
    }
}
