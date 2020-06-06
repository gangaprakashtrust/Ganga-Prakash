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
    public class ModuleController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Module> moduleList = await WebAPIClient.GetAsync<List<Module>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/GetList");
            return View(moduleList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get");
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
                    module = await WebAPIClient.PostAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Create", module);
                    if (module.IsError)
                    {
                        ModelState.AddModelError(module.ErrorMessageFor, module.ErrorMessage);
                        return View(module);
                    }
                    return RedirectToAction("Index");
                }
                return View(module);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Module/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get?Id=" + Id);
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
                    module = await WebAPIClient.PutAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Edit", module);
                    if (module.IsError)
                    {
                        ModelState.AddModelError(module.ErrorMessageFor, module.ErrorMessage);
                        return View(module);
                    }
                    return RedirectToAction("Index");
                }
                return View(module);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Module/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get?Id=" + Id);
            module = await WebAPIClient.PutAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Delete", module);
            return RedirectToAction("Index");
        }
    }
}