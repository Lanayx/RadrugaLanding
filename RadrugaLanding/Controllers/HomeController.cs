using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SendGrid;

namespace RadrugaLanding.Controllers
{
    public class HomeController : Controller
    {
        private const int CacheDuration = 1;

        [Route("")]
        [OutputCache(Duration = CacheDuration)]
        public ActionResult Index()
        {
            return View();
        }

        [Route("en")]
        [OutputCache(Duration = CacheDuration)]
        public ActionResult IndexEn()
        {
            return View();
        }

        [Route("eula")]
        [OutputCache(Duration = CacheDuration)]
        public ActionResult Eula()
        {
            return View();
        }

        [Route("privacy-policy")]
        [OutputCache(Duration = CacheDuration)]
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("send-message")]
        [HttpPost]
        public async Task<ActionResult> SendMessage(Message data)
        {
            if (ModelState.IsValid)
            {
                data.IpAddress = Request.UserHostAddress;
                data.Browser = Request.UserAgent;
                await SendData(data);
                return Json(true);
            }
            return Json(false);
        }


        private async Task SendData(Message data)
        {
            var myMessage = new SendGridMessage();
            myMessage.From = new MailAddress("support@radruga.com");
            myMessage.AddTo("shchurvladimir@gmail.com");
            myMessage.Subject = "User message from site";
            var html = new StringBuilder();
            html.Append(data.Text);
            html.Append("<br>");
            html.Append(data.Browser);
            html.Append("<br>");
            html.Append(data.IpAddress);
            myMessage.Html = html.ToString();

            // Create credentials, specifying your user name and password.
            var credentials = new NetworkCredential("azure_9f0cfd721ec804914e63b38cb34008ed@azure.com", "RadEmail2016");

            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            await transportWeb.DeliverAsync(myMessage);
        }




        public class Message
        {
            [MaxLength(1000)]
            [Required]
            public string Text { get; set; }

            [NotMapped]
            public string IpAddress { get; set; }

            [NotMapped]
            public string Browser { get; set; }
        }
    }
}