using System;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Class for message sending logic
    /// </summary>
    public class MessageController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;
        private readonly IMessageService messageService;

        /// <summary>
        /// Create Message Controller instance
        /// </summary>
        public MessageController(IProfileService ps, IMessageService ms, IUserService us)
        {
            profileService = ps;
            messageService = ms;
            userService = us;
        }
        
        /// <summary>
        /// Returns message page with dialogs
        /// </summary>
        [HttpGet]
        [Authorize]
        public ActionResult Index(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        /// <summary>
        /// Logic of sending new mails
        /// </summary>
        /// <param name="id"destination profiel ID></param>
        /// <param name="chatMessage">message</param>
        /// <returns>Dialog page</returns>
        [HttpGet]
        [Authorize]
        public ActionResult SendMessage(int id, string chatMessage = null)
        {
            var myUser = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            ViewBag.UserId = myUser.Id;
            if (chatMessage != null)
            {
                messageService.AddMessage(new BllMessage()
                {
                    Date = DateTime.Now,
                    ProfileIdFrom = myUser.Id,
                    ProfileIdTo = id,
                    PostId = 0,
                    Text = chatMessage,
                    IsRead = false
                });
            }

            var messages = messageService.GetMessages(myUser.Id, id);
            foreach (var message in messages)
            {
                if (message.IsRead != false || message.ProfileIdTo != myUser.Id) continue;
                message.IsRead = true;
                messageService.ReadMessage(message.Id);
            }

            var viewModel = new SendViewModel()
            {
                Messages = messages,
                I = profileService.Get(myUser.Id).ToViewProfileModel(),
                Companion = profileService.Get(id).ToViewProfileModel()
            };

            if (!Request.IsAjaxRequest())
            {
                return View(viewModel);
            }

            return PartialView("_History", viewModel);
        }

        /// <summary>
        /// Additional method for notifications
        /// </summary>
        /// <returns>number of unread messages</returns>
        [HttpPost]
        public ActionResult NumOfUnread(int id)
        {
            return Content($"  +{messageService.NumsOfUnreadMessage(id)}");
        }
    }
}