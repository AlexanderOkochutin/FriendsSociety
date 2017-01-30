using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Filters;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    /// <summary>
    ///  Class for Profile logic on website
    /// </summary>
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IFileService fileService;
        private readonly IUserService userService;
        private readonly IInviteService inviteService;

        /// <summary>
        /// Create Profiel Conteroller instance
        /// </summary>
        public ProfileController(IProfileService ps, IFileService fs, IUserService us,IInviteService ins)
        {
            profileService = ps;
            userService = us;
            fileService = fs;
            inviteService = ins;
        }

        /// <summary>
        /// Start page of profile
        /// </summary>
        [Authorize]
        public ActionResult Index()
        {
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);          
            if (user == null) return RedirectToAction("Login", "Account");
            var profile = profileService.Get(user.Id);
            var viewModel = profile.ToViewProfileModel();
            viewModel.GalleryId = fileService.GetAllGalleryFiles(profile.Id).Select(g => g.Id).ToList();
            ViewBag.UserId = user.Id;
            return View(viewModel);
        }

        /// <summary>
        /// Show page of another profile or redirect to your page
        /// </summary>
        [Authorize]
        public ActionResult UserProfile(int id = 0)
        {
            
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var user = userService.GetUserByEmail(HttpContext.User.Identity.Name);
            ViewBag.UserId = user.Id;
            var profile = profileService.Get(id);
            var viewModel = profile.ToViewProfileModel();
            viewModel.GalleryId = fileService.GetAllGalleryFiles(profile.Id).Select(g => g.Id).ToList();
            if (user.Id == id)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index",viewModel);
            }
        }

        /// <summary>
        /// page of editing profile info
        /// </summary>
        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            var profile = profileService.GetByUserEmail(HttpContext.User.Identity.Name);
            ViewBag.UserId = profile.Id;
            return View(profile.ToViewProfileModel());
        }

        /// <summary>
        /// Edit post method and return to homepage
        /// </summary>
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

        /// <summary>
        /// Set avatar image to the profile
        /// </summary>
        private void SetProfileImage(ProfileViewModel model, HttpPostedFileBase fileUpload)
        {
            var photo = new FileViewModel();
            WebImage webImageResizer = new WebImage(fileUpload.InputStream);
            webImageResizer.Resize(300, 300);            
            if (!ReferenceEquals(fileUpload, null))
            {
                var previousAvatar = fileService.GetAllFiles(model.Id).FirstOrDefault(p => p.Name == $"avatar{model.Id}");
                if (previousAvatar != null)
                {
                    fileService.DeleteFile(previousAvatar);
                }
                photo.Data = webImageResizer.GetBytes();
                photo.Name = $"avatar{model.Id}";                
                photo.MimeType = fileUpload.ContentType;
                photo.Date = DateTime.Now;
                photo.ProfileId = model.Id;
                photo.PostId = 0;
                fileService.AddFile(photo.ToBllFile());
            }
        }

        /// <summary>
        /// return image pf profile with Id
        /// </summary>
        [Authorize]
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

        /// <summary>
        /// return standart image
        /// </summary>
        private FileContentResult StandartImage()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/default-avatar.jpg");
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "image/jpg");
        }    
    }
}