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
                accessToken.access_token = await WebAPIClient.Login(ConfigurationManager.AppSettings["APIAdministration"], "token", loginModel);
                Session["AccessToken"] = accessToken.access_token;
                return RedirectToAction("Index", "Module", new { Area = "Administration" });
            }
            return View(loginModel);
        }
    }
}