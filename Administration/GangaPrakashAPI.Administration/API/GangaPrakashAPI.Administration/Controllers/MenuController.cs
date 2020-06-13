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
    public class MenuController : ApiController
    {
        [Route("api/Menu/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Menu> menuList = MenuList.GetList();
            return Ok(menuList);
        }

        [Route("api/Menu/GetNVList")]
        [HttpGet]
        public IHttpActionResult GetNVList()
        {
            List<KeyValuePair<Guid, String>> menuNVList = MenuNVList.GetList();
            return Ok(menuNVList);
        }

        [Route("api/Menu/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Menu menu = MenuPersister.Get();
            return Ok(menu);
        }

        [Route("api/Menu/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            Menu menu = MenuPersister.GetMenu(Id);
            return Ok(menu);
        }

        [Route("api/Menu/Create")]
        [HttpPost]
        public IHttpActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                MenuPersister menuPersister = MenuPersister.GetPersister();
                menuPersister.Insert(menu);
                return Ok(menu);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Menu/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                MenuPersister menuPersister = MenuPersister.GetPersister();
                menuPersister.Update(menu);
                return Ok(menu);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Menu/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(Menu menu)
        {
            MenuPersister menuPersister = MenuPersister.GetPersister();
            menuPersister.Delete(menu);
            return Ok(menu);
        }
    }
}
