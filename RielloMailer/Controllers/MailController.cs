using Microsoft.AspNetCore.Mvc;


using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RielloMailer.Controllers
{
    [ApiController]
    [Route("mail")]
    public class MailController : ControllerBase
    {
        private static string subject = "Warning";
        private static string recipientEmail = "softasoftic7@gmail.com";
        private static string body = "This device is in Warning";

        [HttpPost]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                MailMessage newMail = new MailMessage();
                newMail.To.Add(recipientEmail);
                newMail.Subject = subject;
                newMail.Body = body;
                newMail.From = new MailAddress("rietemai@outlook.com", "RielloApp");
                newMail.IsBodyHtml = true;

                SmtpClient SmtpSender = new SmtpClient();
                SmtpSender.Port = 587;
                SmtpSender.Host = "smtp-mail.outlook.com";
                SmtpSender.EnableSsl = true;

                SmtpSender.Credentials = new NetworkCredential("rietemai@outlook.com", "testingapp11");

                await SmtpSender.SendMailAsync(newMail);

                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Email could not be sent. Error: {ex.Message}");
            }
        }
    }
}

