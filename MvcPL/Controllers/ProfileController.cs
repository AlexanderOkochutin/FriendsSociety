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
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IFileService fileService;
        private readonly IUserService userService;
        private readonly IInviteService inviteService;

        public ProfileController(IProfileService ps, IFileService fs, IUserService us,IInviteService ins)
        {
            profileService = ps;
            userService = us;
            fileService = fs;
            inviteService = ins;
        }

        [Authorize]
        public ActionResult Index()
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            if (user == null) return RedirectToAction("Login", "Account");
            var profile = profileService.Get(user.Id);
            return View(profile.ToViewProfileModel());
        }

        [Authorize]
        [Route("User", Name = "User")]
        public ActionResult UserProfile(int id)
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var profile = profileService.Get(id);
            if (user.Id == id)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(profile.ToViewProfileModel());
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var profile = profileService.Get(user.Id);
            return View(profile.ToViewProfileModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(ProfileViewModel model, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                SetProfileImage(model, fileUpload);
                profileService.Update(model.ToBllProfile());
            }
            return RedirectToAction("Index");
        }

        private void SetProfileImage(ProfileViewModel model, HttpPostedFileBase fileUpload)
        {
            var photo = new FileViewModel();            
            if (!ReferenceEquals(fileUpload, null))
            {
                var previousAvatar = fileService.GetAllFiles(model.Id).FirstOrDefault(p => p.Name == $"avatar{model.Id}");
                if (previousAvatar != null)
                {
                    previousAvatar.Name = "galery";
                    fileService.UpdateFile(previousAvatar);
                }
                photo.Name = $"avatar{model.Id}";                
                photo.Data = new byte[fileUpload.ContentLength];
                fileUpload.InputStream.Read(photo.Data, 0, fileUpload.ContentLength);
                photo.MimeType = fileUpload.ContentType;
                photo.Date = DateTime.Now;
                photo.ProfileId = model.Id;
                photo.PostId = 0;
                fileService.AddFile(photo.ToBllFile());
            }
        }

        [AllowAnonymous]
        public FileContentResult GetImage(int id)
        {
            
            var profile = profileService.Get(id);
            if (profile != null)
            {
                var name = $"avatar{id}";
                var photo = fileService.GetByName(name);
                if (photo != null)
                {
                    return File(photo.Data, photo.MimeType);
                }
                else
                {
                    return StandartImage();
                }
            }
            return null;
        }

        private FileContentResult StandartImage()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/default-avatar.jpg");
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "image/jpg");
        }    
    }
}