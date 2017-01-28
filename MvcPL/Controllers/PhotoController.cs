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
        public ActionResult Index()
        {           
            return View();
        }

        [Authorize]
        public FileContentResult GetGalleryImage(int idPhoto)
        {
                var photo = fileService.GetFile(idPhoto);
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
        public void AddPhoto(int profileId,HttpPostedFileBase fileUpload)
        {
            var photo = new FileViewModel();
            if (!ReferenceEquals(fileUpload, null))
            {
                photo.Data = new byte[fileUpload.ContentLength];
                fileUpload.InputStream.Read(photo.Data, 0, fileUpload.ContentLength);
                photo.MimeType = fileUpload.ContentType;
                photo.Name = "galery";
                photo.Date = DateTime.Now;
                photo.ProfileId = profileId;
                photo.PostId = 0;
                fileService.AddFile(photo.ToBllFile());
            }
        }
    }
}