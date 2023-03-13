using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MailSMPT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendSSMPT : Controller
    {
        [HttpPost]
        [Route("sendReq")]
        public async Task<IActionResult> SendMail(string body)
        {
            //RespuestaAPI response = new RespuestaAPI();
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("hilma.walker@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("hilma.walker@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body};

            var smpt = new SmtpClient();
            await smpt.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            await smpt.AuthenticateAsync("hilma.walker@ethereal.email", "g1ruw2eMPbZF7JkgVf");
            await smpt.SendAsync(email);
            await smpt.DisconnectAsync(true);

            return Ok();
            
        }

        
    }
}
