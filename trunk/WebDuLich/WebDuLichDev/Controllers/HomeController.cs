using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.WebUtility;

namespace WebDuLichDev.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Language(string languageCode)
        {
            try
            {
                string url = Request.UrlReferrer.AbsoluteUri;
                WebDuLichSecurity.LanguageCode = languageCode;
                return Redirect(url);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
