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
        public async Task<ActionResult> CreateAsync()
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get");
            return View(module);
        }

        // POST: CarType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Module module)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (module.Id != null && module.Id != Guid.Empty)
                    {
                        module = await WebAPIClient.PostAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Edit", module);
                    }
                    else
                    {
                        module = await WebAPIClient.PostAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Create", module);

                    }
                    if (module.IsError)
                    {
                        ModelState.AddModelError(module.ErrorMessageFor, module.ErrorMessage);
                        return View(module);
                    }
                    return RedirectToAction("Index");
                }
                return View(module);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: CarType/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            Module module = await WebAPIClient.GetAsync<Module>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/Get?Id="+id);
            return View("Create", module);
        }
    }
}