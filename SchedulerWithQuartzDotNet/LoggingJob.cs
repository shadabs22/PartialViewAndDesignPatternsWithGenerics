using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWithQuartzDotNet
{
    public class LoggingJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage("shadabs22@gmail.com", "shadabs22@gmail.com"))
            {
                message.Subject = "Message Subject test";
                message.Body = "Message body test at " + DateTime.Now;
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

        Task IJob.Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
