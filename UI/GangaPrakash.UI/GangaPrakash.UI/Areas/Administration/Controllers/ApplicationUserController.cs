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
    public class ApplicationUserController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<ApplicationUser> applicationUserList = await WebAPIClient.GetAsync<List<ApplicationUser>>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/GetList", Session["AccessToken"].ToString());
            return View(applicationUserList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ApplicationUserTrans applicationUserTrans = await WebAPIClient.GetAsync<ApplicationUserTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/Get", Session["AccessToken"].ToString());
            return View(applicationUserTrans);
        }

        // POST: ApplicationUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUserTrans applicationUserTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    applicationUserTrans = await WebAPIClient.PostAsync<ApplicationUserTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/Create", applicationUserTrans, Session["AccessToken"].ToString());
                    if (applicationUserTrans.applicationUser.IsError)
                    {
                        ModelState.AddModelError(applicationUserTrans.applicationUser.ErrorMessageFor, applicationUserTrans.applicationUser.ErrorMessage);
                        return View(applicationUserTrans);
                    }
                    TempData["Message"] = "User Added Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(applicationUserTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: ApplicationUser/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            ApplicationUserTrans applicationUserTrans = await WebAPIClient.GetAsync<ApplicationUserTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", applicationUserTrans);
        }

        // POST: ApplicationUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUserTrans applicationUserTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    applicationUserTrans = await WebAPIClient.PutAsync<ApplicationUserTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/Edit", applicationUserTrans, Session["AccessToken"].ToString());
                    if (applicationUserTrans.applicationUser.IsError)
                    {
                        ModelState.AddModelError(applicationUserTrans.applicationUser.ErrorMessageFor, applicationUserTrans.applicationUser.ErrorMessage);
                        return View(applicationUserTrans);
                    }
                    TempData["Message"] = "User Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(applicationUserTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: ApplicationUser/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            ApplicationUserTrans applicationUserTrans = await WebAPIClient.GetAsync<ApplicationUserTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/Get?Id=" + Id, Session["AccessToken"].ToString());
            applicationUserTrans = await WebAPIClient.PutAsync<ApplicationUserTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/ApplicationUser/Delete", applicationUserTrans, Session["AccessToken"].ToString());
            if (applicationUserTrans.applicationUser.IsError)
            {
                TempData["Message"] = applicationUserTrans.applicationUser.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "ApplicationUser Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }
    }
}