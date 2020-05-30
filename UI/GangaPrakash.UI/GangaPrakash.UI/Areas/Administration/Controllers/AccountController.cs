using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
        public async System.Threading.Tasks.Task<ActionResult> Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                AccessToken accessToken = new AccessToken();
                accessToken.access_token = await WebAPIClient.Login(ConfigurationManager.AppSettings["APIAdministration"], "token", loginModel);
            }
            return View(loginModel);
        }
    }
}