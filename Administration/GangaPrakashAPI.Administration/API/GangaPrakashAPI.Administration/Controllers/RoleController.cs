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
    //[Authorize]
    public class RoleController : ApiController
    {
        [Route("api/Role/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Role> roleList = RoleList.GetList();
            return Ok(roleList);
        }

        [Route("api/Role/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Role role = RolePersister.Get();
            return Ok(role);
        }

        [Route("api/Role/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            Role role = RolePersister.GetRole(Id);
            return Ok(role);
        }

        [Route("api/Role/Create")]
        [HttpPost]
        public IHttpActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                RolePersister rolePersister = RolePersister.GetPersister();
                rolePersister.Insert(role);
                return Ok(role);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Role/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                RolePersister rolePersister = RolePersister.GetPersister();
                rolePersister.Update(role);
                return Ok(role);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Role/Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(Role role)
        {
            RolePersister rolePersister = RolePersister.GetPersister();
            rolePersister.Delete(role);
            return Ok(role);
        }
    }
}
