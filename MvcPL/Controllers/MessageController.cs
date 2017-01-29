using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class MessageController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;
        private readonly IMessageService messageService;

        public MessageController(IProfileService ps, IMessageService ms, IUserService us)
        {
            profileService = ps;
            messageService = ms;
            userService = us;
        }
        // GET: Message
        public ActionResult Index(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

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

        [HttpPost]
        public ActionResult NumOfUnread(int id)
        {
            return Content($"  +{messageService.NumsOfUnreadMessage(id)}");
        }
    }
}