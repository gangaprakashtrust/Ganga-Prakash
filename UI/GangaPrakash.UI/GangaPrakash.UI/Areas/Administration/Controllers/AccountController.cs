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
    public class AccountController : Controller
    {
        // GET: Administration/Account
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AccessToken accessToken = new AccessToken();
                accessToken = await WebAPIClient.Login(ConfigurationManager.AppSettings["APIAdministration"], "token", loginModel);
                Session["AccessToken"] = accessToken.access_token;
                Session["ApplicationUserId"] = accessToken.ApplicationUserId;
                Session["ApplicationUsername"] = accessToken.userName;
                return RedirectToAction("Index", "Module", new { Area = "Administration" });
            }
            return View(loginModel);
        }

        public async Task<ActionResult> GetUserAcessMenus()
        {
            Guid ApplicationUserId = Guid.Parse(Session["ApplicationUserId"].ToString());
            List<UserAccessMenu> menuList = await WebAPIClient.GetAsync<List<UserAccessMenu>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/GetListByApplicationUserId?ApplicationUserId="+ ApplicationUserId, Session["AccessToken"].ToString());
            return PartialView("_GetUserAcessMenus", menuList);
        }
        public ActionResult Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Session.Remove("AccessToken");
            return RedirectToAction("Login", "Account", new { Area = "Administration" });
        }
    }
}