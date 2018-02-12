using Quartz;
using System;
using System.Net;
using System.Net.Mail;

namespace WebApplication3
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage("shadabs22@gmail.com", "shadabs22@gmail.com"))
            {
                message.Subject = "Test";
                message.Body = "Test at " + DateTime.Now;
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("shadabs22@gmail.com", "9664320412123")
                })
                {
                    client.Send(message);
                }
            }
        }
    }
}