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
    public class PrivilegeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Privilege> privilegeList = await WebAPIClient.GetAsync<List<Privilege>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/GetList");
            return View(privilegeList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Privilege privilege = await WebAPIClient.GetAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Get");
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
                    privilege = await WebAPIClient.PostAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Create", privilege);
                    if (privilege.IsError)
                    {
                        ModelState.AddModelError(privilege.ErrorMessageFor, privilege.ErrorMessage);
                        return View(privilege);
                    }
                    return RedirectToAction("Index");
                }
                return View(privilege);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Privilege/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Privilege privilege = await WebAPIClient.GetAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Get?Id=" + Id);
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
                    privilege = await WebAPIClient.PutAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Edit", privilege);
                    if (privilege.IsError)
                    {
                        ModelState.AddModelError(privilege.ErrorMessageFor, privilege.ErrorMessage);
                        return View(privilege);
                    }
                    return RedirectToAction("Index");
                }
                return View(privilege);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Privilege/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Privilege privilege = await WebAPIClient.GetAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Get?Id=" + Id);
            privilege = await WebAPIClient.PutAsync<Privilege>(ConfigurationManager.AppSettings["APIAdministration"], "api/Privilege/Delete", privilege);
            return RedirectToAction("Index");
        }
    }
}