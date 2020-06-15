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
    public class PrivilegeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<Privilege> privilegeList = await WebAPIClient.GetAsync<List<Privilege>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/GetList", Session["AccessToken"].ToString());
            return View(privilegeList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Privilege privilege = await WebAPIClient.GetAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Get", Session["AccessToken"].ToString());
            return View(privilege);
        }

        // POST: Privilege/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Privilege privilege)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    privilege = await WebAPIClient.PostAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Create", privilege, Session["AccessToken"].ToString());
                    if (privilege.IsError)
                    {
                        ModelState.AddModelError(privilege.ErrorMessageFor, privilege.ErrorMessage);
                        return View(privilege);
                    }
                    TempData["Message"] = "Privilege Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(privilege);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Privilege/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Privilege privilege = await WebAPIClient.GetAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", privilege);
        }

        // POST: Privilege/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Privilege privilege)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    privilege = await WebAPIClient.PutAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Edit", privilege, Session["AccessToken"].ToString());
                    if (privilege.IsError)
                    {
                        ModelState.AddModelError(privilege.ErrorMessageFor, privilege.ErrorMessage);
                        return View(privilege);
                    }
                    TempData["Message"] = "Privilege Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(privilege);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Privilege/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Privilege privilege = await WebAPIClient.GetAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Get?Id=" + Id, Session["AccessToken"].ToString());
            privilege = await WebAPIClient.PutAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Delete", privilege, Session["AccessToken"].ToString());
            if (privilege.IsError)
            {
                TempData["Message"] = privilege.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Privilege Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }
    }
}