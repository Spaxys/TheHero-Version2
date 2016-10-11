using hero2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace hero2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Intro()
        {
            return View();
        }
        public ActionResult Intro2()
        {
            return View();
        }
        public ActionResult Intro3()
        {
            return View();
        }
        public ActionResult ChooseAdventure()
        {
            return View();
        }

        public ActionResult FirstObsticle()
        {
            return View();
        }
        public ActionResult LabyrinthOfDelusion()
        {
            return View();
        }
        public ActionResult Secret_Entrence()
        {
            return View();
        }
        public ActionResult EndFight()
        {
            return View();
        }
        public ActionResult Lost()
        {
            return View();
        }
        public ActionResult Win()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For any inquiries, please contact us:";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress("herogame.group@gmail.com");
                    StringBuilder sb = new StringBuilder();
                    msg.IsBodyHtml = false;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new System.Net.NetworkCredential("herogame.group@gmail.com", "Hero_1234");
                    msg.To.Add("herogame.group@gmail.com");
                    msg.From = from;
                    msg.Subject = "Contact inquiry";
                    sb.Append("First name: " + c.FirstName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Last name: " + c.LastName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Comments: " + c.Comment);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View();
        }
    }
}