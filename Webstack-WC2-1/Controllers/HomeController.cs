using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Webstack_WC2_1.Database;
using Webstack_WC2_1.Models;

namespace Webstack_WC2_1.Controllers
{
    public class HomeController : Controller
    {
        ProductContext context = new ProductContext();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Producten(string SelectedCategory = "")
        {
            ProductViewModel productViewModel = new ProductViewModel();
            if (SelectedCategory != string.Empty)
            {
                productViewModel.Products = context.GetProductsBySoort(SelectedCategory);
            }
            else
            {
                productViewModel.Products = context.Products;
            }
            productViewModel.CategorieSelectList = new SelectList(context.GetTypesEnumerable());
            productViewModel.SelectedCategory = 0;

            return View(productViewModel);
        }

        public ActionResult Openingsuren()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="email"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(string naam = "", string email = "", string body = "")
        {
            if (naam == string.Empty || email == string.Empty || body == string.Empty)
            {
                ViewBag.naam = naam;
                ViewBag.email = email;
                ViewBag.body = body;
                return View();
            }

            MailMessage mail = new MailMessage();
            mail.To.Add("dries.christiaens@student.ehb.be");
            mail.From = new MailAddress("dries.christiaens@student.ehb.be");
            mail.Subject = "Contact Form: " + naam;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("dries.christiaens@student.ehb.be", "");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            ViewBag.verzonden = true;
            return View(); 
        }
    }
}
