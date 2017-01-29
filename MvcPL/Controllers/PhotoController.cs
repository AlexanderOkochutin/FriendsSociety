﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BLL.Interface.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class PhotoController : Controller
    {

        private readonly IProfileService profileService;
        private readonly IFileService fileService;

        public PhotoController(IProfileService ps, IFileService fs)
        {
            profileService = ps;
            fileService = fs;
        }

        // GET: Photo
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            
            var profile = profileService.Get(id);
            ViewBag.UserId = profileService.GetByUserEmail(HttpContext.User.Identity.Name).Id;
            var viewModel = profile.ToViewProfileModel();
            viewModel.GalleryId = fileService.GetAllGalleryFiles(profile.Id).Select(g => g.Id).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(int id,string s)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public FileContentResult GetGalleryImage(int id)
        {
                var photo = fileService.GetFile(id);
                if (photo != null)
                {
                    return File(photo.Data, photo.MimeType);
                }
                else
                {
                    return null;
                }
        }

        [Authorize]
        public void AddPhoto(HttpPostedFileBase fileUpload,int id)
        {
             
            var photo = new FileViewModel();
            WebImage webImageResizer = new WebImage(fileUpload.InputStream);
            webImageResizer.Resize(300, 300);
            if (!ReferenceEquals(fileUpload, null))
            {
                photo.Data = webImageResizer.GetBytes();
                photo.MimeType = fileUpload.ContentType;
                photo.Name = "galery";
                photo.Date = DateTime.Now;
                photo.ProfileId = id;
                photo.PostId = 0;
                fileService.AddFile(photo.ToBllFile());
            }
        }

        [HttpPost]
        public  ActionResult Upload(int id)
        {
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                      AddPhoto(upload, id);
                }
            }
            return RedirectToAction("Index", "Photo", id);
        }


    }
}