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
    }
}