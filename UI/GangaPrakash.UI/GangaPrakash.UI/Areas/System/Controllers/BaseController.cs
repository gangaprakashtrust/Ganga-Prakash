using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GangaPrakash.UI
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(String.IsNullOrEmpty(Convert.ToString(Session["AccessToken"])))
            {
                filterContext.Result = new RedirectResult("/Administration/Account/login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}