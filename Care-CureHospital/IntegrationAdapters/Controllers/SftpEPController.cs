using Backend.Repository.DoctorRepository;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpEPController : ControllerBase
    {
        public void SendNotificationEPrescription()
        {
            try
            {
                Console.WriteLine("E-mail EPrescription se salje!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress("hospitalssystem@gmail.com");
                email.To.Add("pharmacysistem@gmail.com");
                email.Subject = ("Nofication about send file");
                email.Body = "We sent you a new ePrescription!";

                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential("hospitalssystem@gmail.com", "bolnica123");
                smpt.EnableSsl = true;
                smpt.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("E-mail EPrescription se ne salje!");
            }
        }
        public EPrescriptionRepository ePrescriptionRepository;
        [HttpGet]
        public IActionResult SendFileEP()
        {
            try
            {
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.0.19", "tester", "password")))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("EPrescription:");
                    String medRep = builder.ToString();
                    var test = "Files\\eprescription.txt";
                    System.IO.File.WriteAllText(test, medRep);
                    
                    client.Connect();
                    client.UploadFile(System.IO.File.OpenRead(test), @"" + Path.GetFileName(test), x => { Console.WriteLine(x); });

                    SendNotificationEPrescription();
                    client.Disconnect();
                }
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message + "Failed");
            }
        }
    }
}
