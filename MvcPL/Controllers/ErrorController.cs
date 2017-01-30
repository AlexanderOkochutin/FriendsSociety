using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Log.Interface;

namespace MvcPL.Controllers
{
    /// <summary>
    /// Class for error logic. Returns various error pages
    /// </summary>
    public class ErrorController : Controller
    {
        private readonly ILogger logger;

        /// <summary>
        /// Create error controller
        /// </summary>
        public ErrorController(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// returns error page
        /// </summary>
        public ActionResult Index(Exception exception, int httpErrorCode = 0)
        {
            if (httpErrorCode == 404)
            return View("NotFound");
            logger.LogError(exception);
            return View("Error");
        }
    }
}