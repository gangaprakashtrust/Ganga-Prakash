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
    public class RoleController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<Role> roleList = await WebAPIClient.GetAsync<List<Role>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/GetList", Session["AccessToken"].ToString());
            return View(roleList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            RoleTrans roleTrans = await WebAPIClient.GetAsync<RoleTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Get", Session["AccessToken"].ToString());
            return View(roleTrans);
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleTrans roleTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roleTrans = await WebAPIClient.PostAsync<RoleTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Create", roleTrans, Session["AccessToken"].ToString());
                    if (roleTrans.role.IsError)
                    {
                        ModelState.AddModelError(roleTrans.role.ErrorMessageFor, roleTrans.role.ErrorMessage);
                        return View(roleTrans);
                    }
                    TempData["Message"] = "Role Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(roleTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            RoleTrans roleTrans = await WebAPIClient.GetAsync<RoleTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", roleTrans);
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleTrans roleTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roleTrans = await WebAPIClient.PutAsync<RoleTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Edit", roleTrans, Session["AccessToken"].ToString());
                    if (roleTrans.IsError)
                    {
                        ModelState.AddModelError(roleTrans.ErrorMessageFor, roleTrans.ErrorMessage);
                        return View(roleTrans);
                    }
                    TempData["Message"] = "Role Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(roleTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissible fade show";
                return RedirectToAction("Index");
            }
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            RoleTrans roleTrans = await WebAPIClient.GetAsync<RoleTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Get?Id=" + Id, Session["AccessToken"].ToString());
            roleTrans = await WebAPIClient.PutAsync<RoleTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Delete", roleTrans, Session["AccessToken"].ToString());
            if (roleTrans.IsError)
            {
                TempData["Message"] = roleTrans.role.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Role Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissible fade show";
            return RedirectToAction("Index");
        }
    }
}