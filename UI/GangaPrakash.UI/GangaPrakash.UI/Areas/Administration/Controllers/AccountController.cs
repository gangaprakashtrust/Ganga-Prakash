using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
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
                if(accessToken.access_token!=null)
                {
                    Session["AccessToken"] = accessToken.access_token;
                    Session["ApplicationUserId"] = accessToken.ApplicationUserId;
                    List<UserAccessMenu> menuList = await WebAPIClient.GetAsync<List<UserAccessMenu>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/GetListByApplicationUserId?ApplicationUserId=" + Guid.Parse(Session["ApplicationUserId"].ToString()), Session["AccessToken"].ToString());
                    Session["AccessMenus"] = menuList;
                    Session["ApplicationUsername"] = accessToken.userName;
                    return RedirectToAction("Index", "Module", new { Area = "Administration" });
                }
              else
                {
                    ModelState.AddModelError("Email", "Invalid Username/Password");
                    return View(loginModel);
                }
            }
            return View(loginModel);
        }

        // GET: Administration/Account
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            return View(forgetPassword);
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgetPassword forgetPassword)
        {
            if (ModelState.IsValid)
            {
                forgetPassword = await WebAPIClient.PostAsync<ForgetPassword>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/ForgotPassword", forgetPassword);
                var PasswordResetLink = Url.Action("ResetPassword", "Account", new { Area = "Administration", Email = forgetPassword.Email, token = forgetPassword.PasswordResetToken },Request.Url.Scheme);
                SendEmail(forgetPassword.Email, "Reset Password", "Please reset your password by clicking <a href=\"" + PasswordResetLink + "\">here</a>");
                TempData["Message"] = "Password reset link sent to Email!";
                TempData["MessageClass"] = "alert alert-success alert-dismissable";
                return RedirectToAction("Login", "Account", new { Area = "Administration" });
            }
            return View(forgetPassword);
        }

        // GET: Administration/Account
        [HttpGet]
        public ActionResult ResetPassword(String Email,String token)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Email = Email;
            resetPassword.PasswordResetToken = token;
            return View(resetPassword);
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPassword resetPassword)
        {
            if (ModelState.IsValid)
            {
                resetPassword = await WebAPIClient.PostAsync<ResetPassword>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/ResetPassword", resetPassword);
                TempData["Message"] = "Password changed successfully!";
                TempData["MessageClass"] = "alert alert-success alert-dismissable";
                return RedirectToAction("Login", "Account", new { Area = "Administration" });
            }
            return View(resetPassword);
        }

        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(ConfirmEmail confirmEmail)
        {
            confirmEmail = await WebAPIClient.PostAsync<ConfirmEmail>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/ConfirmEmail", confirmEmail);
            TempData["Message"] = "Email confirmed successfully!";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Login", "Account", new { Area = "Administration" });
        }

        public static void SendEmail(String Email, String Subject, String Body)
        {
            MailMessage mailMessage = new MailMessage(ConfigurationManager.AppSettings["FromEmailAddress"].ToString(), Email);
            mailMessage.Subject = Subject;
            mailMessage.Body = Body;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }

        public ActionResult Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Session["AccessToken"] = null;
            Session["ApplicationUserId"] = null;
            return RedirectToAction("Login", "Account", new { Area = "Administration" });
        }
    }
}