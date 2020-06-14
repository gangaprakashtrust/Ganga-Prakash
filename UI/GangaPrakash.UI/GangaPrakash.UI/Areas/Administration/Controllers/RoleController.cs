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
            Role role = await WebAPIClient.GetAsync<Role>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Get", Session["AccessToken"].ToString());
            return View(role);
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    role = await WebAPIClient.PostAsync<Role>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Create", role, Session["AccessToken"].ToString());
                    if (role.IsError)
                    {
                        ModelState.AddModelError(role.ErrorMessageFor, role.ErrorMessage);
                        return View(role);
                    }
                    return RedirectToAction("Index");
                }
                return View(role);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Role role = await WebAPIClient.GetAsync<Role>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", role);
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    role = await WebAPIClient.PutAsync<Role>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Edit", role, Session["AccessToken"].ToString());
                    if (role.IsError)
                    {
                        ModelState.AddModelError(role.ErrorMessageFor, role.ErrorMessage);
                        return View(role);
                    }
                    return RedirectToAction("Index");
                }
                return View(role);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Role role = await WebAPIClient.GetAsync<Role>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Get?Id=" + Id, Session["AccessToken"].ToString());
            role = await WebAPIClient.PutAsync<Role>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/Delete", role, Session["AccessToken"].ToString());
            return RedirectToAction("Index");
        }
    }
}