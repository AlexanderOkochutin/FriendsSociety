using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using CryptoService;
using ICryptoService;
using MvcPL.Providers;
using MvcPL.ViewModels;
using Newtonsoft.Json.Linq;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public AccountController(IUserService us, IProfileService ps)
        {
            userService = us;
            profileService = ps;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Login",Name = "Login")]
        public ActionResult Login(LoginAndRegistrationModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid) return View("Index", viewModel);
            if (Membership.ValidateUser(viewModel.LoginModel.Email, viewModel.LoginModel.Password))
            {
                FormsAuthentication.SetAuthCookie(viewModel.LoginModel.Email, viewModel.LoginModel.RememberMe);
                //Управляет службами проверки подлинности с помощью форм для веб-приложений
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    var user = userService.GetUserByEmail(viewModel.LoginModel.Email);
                    if (user.IsEmailConfirmed)
                    {
                        return RedirectToAction("Index", "Profile");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email is not confurmed");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return View("Index",viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Registraion",Name="Registration")]
        public ActionResult Registration(LoginAndRegistrationModel model)
        {

            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdeCREUAAAAAOLw6oV8FAwizRxR7ZNTBH0iSdxV";
            var client = new WebClient();
            var result =
                client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            /*if (!status)
            {
                ModelState.AddModelError("", "captcha failed");
                return View("index",model);
            }*/
            var anyUser = userService.GetAll().Any(u => u.Email == model.RegistrationModel.Email);
            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View("index",model);
            }
            if (ModelState.IsValid)
            {

                var membershipUser = ((SocialNetworkMembershipProvider)Membership.Provider)
                    .CreateUser(model.RegistrationModel);

                MailConfirmation(model.RegistrationModel.Email);

                if (membershipUser != null)
                {
                    return RedirectToAction("Confirm", "Account", new {name = model.RegistrationModel.DisplayName});
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View("index",model);
        }

        public JsonResult IsEmailExist([Bind(Prefix = "RegistrationViewModel")]string Email)
        {
            var result = ((SocialNetworkMembershipProvider)Membership.Provider)
                         .GetUser(Email,false) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public ActionResult Confirm(string name)
        {
            ViewBag.Message =$"{name} check your email to complete your registration";
            return View();
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(string MailSalt,string Email)
        {
            if (!userService.GetUserByEmail(Email).IsEmailConfirmed && userService.GetUserByEmail(Email).MailSalt == MailSalt)
            {
                userService.MailConfirm(Email);
            }
            return RedirectToAction("Index", "Account");
        }


        private void MailConfirmation(string email)
        {
            // наш email с заголовком письма
            MailAddress from = new MailAddress("f-society@mail.com", "fsociety00.dat");
            // кому отправляем
            MailAddress to = new MailAddress(email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Email confirmation";
            // текст письма - включаем в него ссылку

            var mailSalt = userService.GetUserByEmail(email).MailSalt;

            m.Body = string.Format("To complete registration go to this link:" +
                            "<a href=\"{0}\" title=\"Confirm registration\">{0}</a>",
                Url.Action("ConfirmEmail", "Account", new { MailSalt = mailSalt,Email = email}, Request.Url.Scheme));
            m.IsBodyHtml = true;
            // адрес smtp-сервера, с которого мы и будем отправлять письмо
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("okochutinwork@gmail.com", "GooOko331650");
            smtp.Send(m);
        }
    }
}