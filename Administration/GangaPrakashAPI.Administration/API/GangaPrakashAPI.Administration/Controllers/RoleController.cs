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
            RoleTrans roleTrans = RoleTransPersister.Get();
            return Ok(roleTrans);
        }

        [Route("api/Role/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            RoleTrans roleTrans = RoleTransPersister.GetRoleTrans(Id);
            return Ok(roleTrans);
        }

        [Route("api/Role/Create")]
        [HttpPost]
        public IHttpActionResult Create(RoleTrans roleTrans)
        {
            if (ModelState.IsValid)
            {
                RoleTransPersister roleTransPersister = RoleTransPersister.GetPersister();
                roleTransPersister.Insert(roleTrans);
                return Ok(roleTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Role/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(RoleTrans roleTrans)
        {
            if (ModelState.IsValid)
            {
                RoleTransPersister roleTransPersister = RoleTransPersister.GetPersister();
                roleTransPersister.Update(roleTrans);
                return Ok(roleTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Role/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(RoleTrans roleTrans)
        {
            RoleTransPersister roleTransPersister = RoleTransPersister.GetPersister();
            roleTransPersister.Delete(roleTrans);
            return Ok(roleTrans);
        }
    }
}
