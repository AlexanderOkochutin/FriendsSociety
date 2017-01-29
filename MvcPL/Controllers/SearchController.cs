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
    public class SearchController : Controller
    {


        private readonly IProfileService profileService;
        private readonly IFileService fileService;
        private readonly IInviteService inviteService;

        public SearchController(IProfileService ps, IFileService fs, IInviteService ins)
        {
            profileService = ps;
            fileService = fs;
            inviteService = ins;
        }

        public ActionResult Index(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        /// <summary>
        /// Consists logic for user searsh
        /// </summary>
        /// <param name="model"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SearchViewModel model, int page = 1)
        {
            var bllProfiles = profileService.Find(model.StringKey, model.City);
            var searcherId = profileService.GetByUserEmail(HttpContext.User.Identity.Name).Id;
            ViewBag.UserId = searcherId;
            bllProfiles = bllProfiles.Where(p => p.Id != searcherId);
            var result = bllProfiles.Map();
            model.Profiles = new GenericPaginationModel<ProfileViewModel>(page, 5, result.ToList());
            foreach (var profile in model.Profiles.Entities)
            {
                profile.IsYourFriend = profileService.IsYourFriend(searcherId, profile.Id);
                profile.IsYouSendInvite = inviteService.IsInviteSend(searcherId, profile.Id);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Search", model);
            }
            else
            {
                return View(model);
            }
        }

        /// <summary>
        /// Returns json autocomplete help
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult FindProfiles(string term)
        {
            var mvcProfiles = profileService.Find(term).Select(p => p.FirstName + " " + p.LastName);
            return Json(mvcProfiles.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}