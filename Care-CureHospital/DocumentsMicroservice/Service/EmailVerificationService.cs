using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Service
{
    public class EmailVerificationService : IEmailVerificationService
    {
        public EmailVerificationService() { }

        public void SendVerificationEmailLink(MailAddress recipientEmailAddress, string username)
        {
            MailAddress senderAddress = new MailAddress("pswfirma8@gmail.com");
            SmtpClient smtp = CreateSmtpClient(senderAddress, "8firmapsw");
            MailMessage message = CreateMailMessage(senderAddress, recipientEmailAddress, username);
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

        private SmtpClient CreateSmtpClient(MailAddress senderEmailAddress, string senderPassword)
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmailAddress.Address, senderPassword)
            };
        }

        private MailMessage CreateMailMessage(MailAddress senderEmailAddress, MailAddress recipientEmailAddress, string username)
        {
            return new MailMessage(senderEmailAddress, recipientEmailAddress)
            {
                Subject = "Verifikacija pacijentovog naloga",
                Body = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\WebAppPatient\\wwwroot\\html\\emailVerification.html").Replace("#username#", username)
            };
        }
    }
}
