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
    public class MenuController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<Menu> menuList = await WebAPIClient.GetAsync<List<Menu>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/GetList", Session["AccessToken"].ToString());
            return View(menuList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            MenuTrans menuTrans = await WebAPIClient.GetAsync<MenuTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Get", Session["AccessToken"].ToString());
            await AssignList(menuTrans);
            return View(menuTrans);
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuTrans menuTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuTrans = await WebAPIClient.PostAsync<MenuTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Create", menuTrans, Session["AccessToken"].ToString());
                    if (menuTrans.menu.IsError)
                    {
                        ModelState.AddModelError(menuTrans.menu.ErrorMessageFor, menuTrans.menu.ErrorMessage);
                        await AssignList(menuTrans);
                        return View(menuTrans);
                    }
                    TempData["Message"] = "Menu Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(menuTrans);
                return View(menuTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Menu/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            MenuTrans menuTrans = await WebAPIClient.GetAsync<MenuTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Get?Id=" + Id, Session["AccessToken"].ToString());
            await AssignList(menuTrans);
            return View("Edit", menuTrans);
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MenuTrans menuTrans)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuTrans = await WebAPIClient.PutAsync<MenuTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Edit", menuTrans, Session["AccessToken"].ToString());
                    if (menuTrans.menu.IsError)
                    {
                        ModelState.AddModelError(menuTrans.menu.ErrorMessageFor, menuTrans.menu.ErrorMessage);
                        await AssignList(menuTrans);
                        return View(menuTrans);
                    }
                    TempData["Message"] = "Menu Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(menuTrans);
                return View(menuTrans);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Menu/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            MenuTrans menuTrans = await WebAPIClient.GetAsync<MenuTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Get?Id=" + Id, Session["AccessToken"].ToString());
            menuTrans = await WebAPIClient.PutAsync<MenuTrans>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Delete", menuTrans, Session["AccessToken"].ToString());
            if (menuTrans.menu.IsError)
            {
                TempData["Message"] = menuTrans.menu.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Menu Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetParentMenuByModuleId(Guid Id)
        {
            List<KeyValuePair<Guid, string>> ParentMenuList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/GetParentMenuListByModuleId?ModuleId="+Id, Session["AccessToken"].ToString());
            return Json(ParentMenuList, JsonRequestBehavior.AllowGet);
        }

        public async Task AssignList(MenuTrans menuTrans)
        {
            menuTrans.menu.MenuNVList = new List<KeyValuePair<Guid, string>>();
            menuTrans.menu.ModuleNVList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/GetNVList", Session["AccessToken"].ToString());
        }
    }
}