using GangaPrakashAPI.Configuration.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Configuration.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        [Route("api/Department/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Department> departmentList = DepartmentList.GetList();
            return Ok(departmentList);
        }

        [Route("api/Department/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Department department = DepartmentPersister.Get();
            return Ok(department);
        }

        [Route("api/Department/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            Department department = DepartmentPersister.GetDepartment(Id);
            return Ok(department);
        }

        [Route("api/Department/Create")]
        [HttpPost]
        public IHttpActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartmentPersister departmentPersister = DepartmentPersister.GetPersister();
                departmentPersister.Insert(department);
                return Ok(department);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Department/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartmentPersister departmentPersister = DepartmentPersister.GetPersister();
                departmentPersister.Update(department);
                return Ok(department);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Department/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(Department department)
        {
            DepartmentPersister departmentPersister = DepartmentPersister.GetPersister();
            departmentPersister.Delete(department);
            return Ok(department);
        }
    }
}
