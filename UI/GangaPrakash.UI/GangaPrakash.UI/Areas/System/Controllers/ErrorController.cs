using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GangaPrakash.UI
{
    public class ErrorController : Controller
    {
        // GET: System/Error
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}