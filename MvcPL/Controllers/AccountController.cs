using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Filters;
using MvcPL.Providers;
using MvcPL.ViewModels;
using Newtonsoft.Json.Linq;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Class for account logic on website: login,registration,mail confirm.
    /// </summary>
    public class AccountController : Controller
    {

        private readonly IUserService userService;
        private readonly IProfileService profileService;

        /// <summary>
        /// Create account controller
        /// </summary>
        public AccountController(IUserService us, IProfileService ps)
        {
            userService = us;
            profileService = ps;
        }

        /// <summary>
        /// Start action of website, if you not checkin
        /// </summary>
        /// <returns>Start page</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Login post logic
        /// </summary>
        /// <param name="viewModel">login and registration view model</param>
        /// <returns>homepage of profile, or the same page</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginAndRegistrationModel viewModel)
        {
            if (!ModelState.IsValid) return View("Index", viewModel);
            if (Membership.ValidateUser(viewModel.LoginModel.Email, viewModel.LoginModel.Password))
            {
                FormsAuthentication.SetAuthCookie(viewModel.LoginModel.Email,viewModel.LoginModel.RememberMe);
                var user = userService.GetUserByEmail(viewModel.LoginModel.Email);
                if (user.IsEmailConfirmed)
                {
                    return RedirectToAction("Index", "Profile");
                }

                ModelState.AddModelError("", "Email is not confurmed");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return View("Index", viewModel);
        }

        /// <summary>
        /// Logic of registration captcha check and mail confirm
        /// </summary>
        /// <param name="model">login and registration view model</param>
        /// <returns>page of mail confirmation or the same page</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(LoginAndRegistrationModel model)
        {

            string response = Request["g-recaptcha-response"];

            if (!CheckCaptcha(response))
            {
                ModelState.AddModelError("", "captcha failed");
                return View("index",model);
            }

            var anyUser = userService.GetAll().Any(u => u.Email == model.RegistrationModel.Email);

            if (anyUser)
            {
                ModelState.AddModelError("", "Email with this name already exist");
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

                ModelState.AddModelError("", "Error registration.");
            }
            return View("index",model);
        }

        /// <summary>
        /// Page after successfuly registration
        /// </summary>
        /// <param name="name">name of user</param>
        /// <returns>page of web confirmaion</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Confirm(string name)
        {
            ViewBag.Message =$"{name} check your email to complete your registration";
            return View();
        }

        /// <summary>
        /// logic of checking email
        /// </summary>
        /// <param name="MailSalt">secret user mail salt</param>
        /// <param name="Email">user email</param>
        /// <returns>login page</returns>
        [AllowAnonymous]
        public ActionResult ConfirmEmail(string MailSalt,string Email)
        {
            if (!userService.GetUserByEmail(Email).IsEmailConfirmed && userService.GetUserByEmail(Email).MailSalt == MailSalt)
            {
                userService.MailConfirm(Email);
            }
            return RedirectToAction("Index", "Account");
        }


        /// <summary>
        /// logic of sending mail for confirmation
        /// </summary>
        /// <param name="email"> user email</param>
        private void MailConfirmation(string email)
        {
            MailAddress from = new MailAddress("f-society@mail.com", "fsociety00.dat");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Email confirmation";
            var mailSalt = userService.GetUserByEmail(email).MailSalt;
            m.Body = string.Format("To complete registration go to this link, and leave me here:" +
                            "<a href=\"{0}\" title=\"Confirm registration\">{0}</a>",
                Url.Action("ConfirmEmail", "Account", new { MailSalt = mailSalt,Email = email}, Request.Url.Scheme));
            m.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("okochutinwork@gmail.com", "GooOko331650");
            smtp.Send(m);
        }

        /// <summary>
        /// method for client mail validation by Remote attribute
        /// </summary>
        /// <param name="RegistrationModel">Registration view model</param>
        /// <returns> nothing or error that this email exist</returns>
        public JsonResult IsEmailExist([Bind(Include = "Email")]RegistrationViewModel RegistrationModel)
        {
            var result = ((SocialNetworkMembershipProvider) Membership.Provider)
                .GetUser(RegistrationModel.Email, false)==null;
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// logout logic
        /// </summary>
        /// <returns> to the login page</returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }

        /// <summary>
        /// About page with logo
        /// </summary>
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Logic of captcha check
        /// </summary>
        /// <returns>status fail or success</returns>
        private bool CheckCaptcha(string response)
        {
            var secretKey = "6LdeCREUAAAAAOLw6oV8FAwizRxR7ZNTBH0iSdxV";
            var client = new WebClient();
            var result =
                client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}");
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            return status;
        }
    }
}