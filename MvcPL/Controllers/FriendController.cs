using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class FriendController : Controller
    {

        private readonly IProfileService profileService;
        private readonly IFileService fileService;
        private readonly IUserService userService;
        private readonly IInviteService inviteService;

        public FriendController(IProfileService ps, IFileService fs, IUserService us, IInviteService ins)
        {
            profileService = ps;
            userService = us;
            fileService = fs;
            inviteService = ins;
        }


        // GET: Friend
        public ActionResult Index(int page = 1)
        {
            var myProfile = profileService.GetByUserEmail(HttpContext.User.Identity.Name);
            var viewModel = new FriendsViewModel();
            viewModel.UserId = myProfile.Id;
            if (myProfile.Friends != null)
            {
                foreach (var friendId in myProfile.Friends)
                {
                    viewModel.Friends.Add(profileService.Get(friendId).ToViewProfileModel());
                }
            }
            var temp = inviteService.GetAllInviteProfiles(myProfile.Id).Map();
            viewModel.FriendsInvites = new GenericPaginationModel<ProfileViewModel>(page,2,temp.ToList());
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Friends",viewModel);
            }
            return View(viewModel);           
        }

        [Authorize]
        public ActionResult ShowUserFriends(int i)
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            if (i == user.Id)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult SendInvite(int id)
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            inviteService.SendInvite(user.Id, id);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_InviteSend");
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Accept(int idFrom,int idTo)
        {
            inviteService.AddFriend(idFrom,idTo);
            return RedirectToAction("Index","Friend");
        }

        [Authorize]
        public ActionResult Refuse()
        {
            throw new NotImplementedException();
        }
    }
}