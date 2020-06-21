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
    public class RoleMenuPrivilegeController : ApiController
    {

        [Route("api/RoleMenuPrivilege/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid RoleId)
        {
            RoleMenuPrivilegeTrans roleMenuPrivilegeTrans = RoleMenuPrivilegeTransPersister.GetRoleMenuPrivilegeTrans(RoleId);
            return Ok(roleMenuPrivilegeTrans);
        }

        [Route("api/RoleMenuPrivilege/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(RoleMenuPrivilegeTrans roleMenuPrivilegeTrans)
        {
            if (ModelState.IsValid)
            {
                RoleMenuPrivilegeTransPersister roleMenuPrivilegeTransPersister = RoleMenuPrivilegeTransPersister.GetPersister();
                roleMenuPrivilegeTransPersister.Update(roleMenuPrivilegeTrans);
                return Ok(roleMenuPrivilegeTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }
    }
}
