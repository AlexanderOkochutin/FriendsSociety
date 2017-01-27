using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;

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
    }
}