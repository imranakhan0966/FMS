using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ozone.Infrastructure.Shared.Services
{
    public class EmailSending
    {
        #region Fields
        IConfiguration _configuration;
        #endregion
        #region ctor
        public EmailSending(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion
        public string EmailRequest(string email, string title, string asset, string description)
        {
            var senderPassword = _configuration["EmailSetup:SenderPassword"];
            var senderEmail = new MailAddress(_configuration["EmailSetup:SenderEmail"], _configuration["EmailSetup:SenderName"]);
            var receiverEmail = new MailAddress(email, "Receiver");
            var password = senderPassword;
            var body = title + "\n" + asset + "\n" + description;
            var smtp = new SmtpClient
            {
                Host = _configuration["EmailSetup:Host"],
                Port = Convert.ToInt32(_configuration["EmailSetup:Port"]),

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                //UseDefaultCredentials = true,

                Credentials = new NetworkCredential(senderEmail.Address, password),
                EnableSsl = true,
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = "Service Request Email",
                Body = body
            })
                try
                {
                    smtp.Send(mess);
                    return "successfully Send";
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            //  smtp.UseDefaultCredentials = false;
            return null;      
        }
    }
}
