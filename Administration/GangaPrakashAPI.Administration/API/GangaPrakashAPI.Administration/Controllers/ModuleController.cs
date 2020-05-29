using GangaPrakashAPI.Administration.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Controllers
{
    [Authorize]
    public class ModuleController : ApiController
    {
        [Route("api/Module/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Module> moduleList = ModuleList.GetList();
            return Ok(moduleList);
        }

        [Route("api/Module/Get/{id}")]
        [HttpGet]
        public IHttpActionResult Get(Int32 Id)
        {
            Module module = ModulePersister.GetModule(Id);
            return Ok(module);
        }

        [Route("api/Module/Create")]
        [HttpPost]
        public IHttpActionResult Create(Module module)
        {
            if (ModelState.IsValid)
            {
                ModulePersister modulePersister = ModulePersister.GetPersister();
                modulePersister.Insert(module);
                return Ok(module);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Module/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(Module module)
        {
            if (ModelState.IsValid)
            {
                ModulePersister modulePersister = ModulePersister.GetPersister();
                modulePersister.Update(module);
                return Ok(module);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Module/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(Module module)
        {
            ModulePersister modulePersister = ModulePersister.GetPersister();
            modulePersister.Delete(module);
            return Ok(module);
        }
    }
}
