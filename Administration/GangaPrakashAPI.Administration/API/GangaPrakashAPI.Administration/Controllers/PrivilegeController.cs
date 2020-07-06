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
    public class PrivilegeController : ApiController
    {
        [Route("api/Privilege/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Privilege> roleList = PrivilegeList.GetList();
            return Ok(roleList);

        }

        [Route("api/Privilege/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Privilege role = PrivilegePersister.Get();
            return Ok(role);
        }

        [Route("api/Privilege/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            Privilege role = PrivilegePersister.GetPrivilege(Id);
            return Ok(role);
        }

        [Route("api/Privilege/Create")]
        [HttpPost]
        public IHttpActionResult Create(Privilege role)
        {
            if (ModelState.IsValid)
            {
                PrivilegePersister rolePersister = PrivilegePersister.GetPersister();
                rolePersister.Insert(role);
                return Ok(role);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Privilege/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(Privilege role)
        {
            if (ModelState.IsValid)
            {
                PrivilegePersister rolePersister = PrivilegePersister.GetPersister();
                rolePersister.Update(role);
                return Ok(role);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Privilege/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(Privilege role)
        {
            PrivilegePersister rolePersister = PrivilegePersister.GetPersister();
            rolePersister.Delete(role);
            return Ok(role);
        }
    }
}
