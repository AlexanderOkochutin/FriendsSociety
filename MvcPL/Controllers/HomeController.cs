using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoService;
using DAL.Concrete;
using ORM;

namespace MvcPL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserRepository test = new UserRepository(new SocialNetworkContext(new PasswordService()));
            var temp = test.GetById(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}