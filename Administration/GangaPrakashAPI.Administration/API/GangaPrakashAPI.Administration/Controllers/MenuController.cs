﻿using GangaPrakashAPI.Administration.Persister;
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
    public class MenuController : ApiController
    {
        [Route("api/Menu/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Menu> menuList = MenuList.GetList();
            return Ok(menuList);
        }

        [Route("api/Menu/GetParentMenuListByModuleId")]
        [HttpGet]
        public IHttpActionResult GetParentMenuListByModuleId(Guid ModuleId)
        {
            List<KeyValuePair<Guid, String>> parentMenuList = MenuNVList.GetParentListByModuleId(ModuleId);
            return Ok(parentMenuList);
        }

        [Route("api/Menu/GetUserMenuBasedOnPrivilege")]
        [HttpGet]
        public IHttpActionResult GetUserMenuBasedOnPrivilege(String Controller, String Action, String Area, Guid ApplicationUserId)
        {
            List<Menu> menuList = MenuList.GetUserMenuBasedOnPrivilege(Controller, Action, Area, ApplicationUserId);
            return Ok(menuList);
        }

        [Route("api/Menu/GetListByApplicationUserId")]
        [HttpGet]
        public IHttpActionResult GetListByApplicationUserId(Guid ApplicationUserId)
        {
            List<UserAccessMenu> menuList = MenuList.GetListByApplicationUserId(ApplicationUserId);
            return Ok(menuList);
        }

        [Route("api/Menu/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            MenuTrans menuTrans = MenuTransPersister.Get();
            return Ok(menuTrans);
        }

        [Route("api/Menu/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            MenuTrans menuTrans = MenuTransPersister.GetMenuTrans(Id);
            return Ok(menuTrans);
        }

        [Route("api/Menu/Create")]
        [HttpPost]
        public IHttpActionResult Create(MenuTrans menuTrans)
        {
            if (ModelState.IsValid)
            {
                MenuTransPersister menuTransPersister = MenuTransPersister.GetPersister();
                menuTransPersister.Insert(menuTrans);
                return Ok(menuTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Menu/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(MenuTrans menuTrans)
        {
            if (ModelState.IsValid)
            {
                MenuTransPersister menuTransPersister = MenuTransPersister.GetPersister();
                menuTransPersister.Update(menuTrans);
                return Ok(menuTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Menu/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(MenuTrans menuTrans)
        {
            MenuTransPersister menuTransPersister = MenuTransPersister.GetPersister();
            menuTransPersister.Delete(menuTrans);
            return Ok(menuTrans);
        }
    }
}
