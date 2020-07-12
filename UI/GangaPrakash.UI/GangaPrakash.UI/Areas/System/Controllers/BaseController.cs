using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GangaPrakash.UI
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (String.IsNullOrEmpty(Convert.ToString(Session["AccessToken"])) || String.IsNullOrEmpty(Convert.ToString(Session["ApplicationUserId"])) || String.IsNullOrEmpty(Convert.ToString(Session["AccessMenus"])) || String.IsNullOrEmpty(Convert.ToString(Session["ApplicationUsername"])))
            {
                filterContext.Result = new RedirectResult("/Administration/Account/login");
            }
            string IsAjaxRequest =  HttpContext.Request.Headers["X-Requested-With"];

            if (IsAjaxRequest != "XMLHttpRequest")
            {
                String Area = filterContext.RouteData.DataTokens["area"].ToString();
                string Controller = filterContext.RouteData.Values["controller"].ToString();
                string Action = filterContext.RouteData.Values["action"].ToString();
                Guid ApplicationUserId = Guid.Parse(Session["ApplicationUserId"].ToString());
                List<Menu> MenuList = Task.Run(async () => await WebAPIClient.GetAsync<List<Menu>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/GetUserMenuBasedOnPrivilege?Controller=" + Controller + "&Action=" + Action + "&Area=" + Area + "&ApplicationUserId=" + ApplicationUserId, Session["AccessToken"].ToString())).Result;
                if (MenuList.Count <= 0)
                {
                    filterContext.Result = new RedirectResult("/System/Error/Unauthorized");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}