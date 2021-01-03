using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace IntegrationTests.IntegrationAdaptersIntegrationTest
{
    public class EmailNotificationTests
    {
        [Fact]
        public void Sends_notification_email()
        {
            sendNotification().ShouldBe(true);
        }
        [Fact]
        public void Sends_no_notification_email()
        {
            sendNoNotification().ShouldBe(false);
        }

        private Boolean sendNotification()
        {
            try
            {
                MailMessage mail = new MailMessage("hospitalssystem@gmail.com", "pharmacysistem@gmail.com", "Notification about send file", "Body of mail address");
                SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
                SmptServer.Credentials = new System.Net.NetworkCredential("hospitalssystem@gmail.com", "bolnica123");
                SmptServer.EnableSsl = true;
                SmptServer.Send(mail);
                return true;
            }
            catch { return false; }

        }
        private Boolean sendNoNotification()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmptServer = new SmtpClient("smtp.gmail.com", 587);
                SmptServer.Credentials = new System.Net.NetworkCredential("hospitalssystem@gmail.com", "bolnica123");
                SmptServer.EnableSsl = true;
                SmptServer.Send(mail);
                return true;
            }
            catch { return false; }

        }
    }
}
