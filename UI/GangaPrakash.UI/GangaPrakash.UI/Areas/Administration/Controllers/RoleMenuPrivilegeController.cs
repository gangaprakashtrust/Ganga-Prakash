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
    public class RoleMenuPrivilegeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            RoleMenuPrivilegeTrans roleMenuPrivilegeTrans = await WebAPIClient.GetAsync<RoleMenuPrivilegeTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/RoleMenuPrivilege/Get", Session["AccessToken"].ToString());
            await AssignList(roleMenuPrivilegeTrans);
            return View(roleMenuPrivilegeTrans);
        }

        // POST: RoleMenuPrivilege/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RoleMenuPrivilegeTrans roleMenuPrivilegeTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roleMenuPrivilegeTrans = await WebAPIClient.PostAsync<RoleMenuPrivilegeTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/RoleMenuPrivilege/Create", roleMenuPrivilegeTrans, Session["AccessToken"].ToString());
                    if (roleMenuPrivilegeTrans.IsError)
                    {
                        TempData["Message"] = roleMenuPrivilegeTrans.ErrorMessage;
                        TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                        await AssignList(roleMenuPrivilegeTrans);
                        return View(roleMenuPrivilegeTrans);
                    }
                    TempData["Message"] = "RoleMenuPrivilege Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(roleMenuPrivilegeTrans);
                return View(roleMenuPrivilegeTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        public async Task AssignList(RoleMenuPrivilegeTrans roleMenuPrivilegeTrans)
        {
            roleMenuPrivilegeTrans.RoleNVList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Role/GetNVList", Session["AccessToken"].ToString());
        }
    }
}