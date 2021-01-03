using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Backend.Service.UsersServices
{
    public interface IEmailVerificationService
    {
        void SendVerificationEmailLink(MailAddress recipientEmailAddress, string username);
    }
}
