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
    public class ModuleController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<Module> moduleList = await WebAPIClient.GetAsync<List<Module>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/GetList", Session["AccessToken"].ToString());
            return View(moduleList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get", Session["AccessToken"].ToString());
            return View(module);
        }

        // POST: Module/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    module = await WebAPIClient.PostAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Create", module, Session["AccessToken"].ToString());
                    if (module.IsError)
                    {
                        ModelState.AddModelError(module.ErrorMessageFor, module.ErrorMessage);
                        return View(module);
                    }
                    TempData["Message"] = "Module Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(module);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Module/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", module);
        }

        // POST: Module/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    module = await WebAPIClient.PutAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Edit", module, Session["AccessToken"].ToString());
                    if (module.IsError)
                    {
                        ModelState.AddModelError(module.ErrorMessageFor, module.ErrorMessage);
                        return View(module);
                    }
                    TempData["Message"] = "Module Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(module);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Module/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get?Id=" + Id, Session["AccessToken"].ToString());
            module = await WebAPIClient.PutAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Delete", module, Session["AccessToken"].ToString());
            if (module.IsError)
            {
                TempData["Message"] = module.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Module Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }
    }
}