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
            Menu menu = await WebAPIClient.GetAsync<Menu>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Get", Session["AccessToken"].ToString());
            await AssignList(menu);
            return View(menu);
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menu = await WebAPIClient.PostAsync<Menu>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Create", menu, Session["AccessToken"].ToString());
                    if (menu.IsError)
                    {
                        ModelState.AddModelError(menu.ErrorMessageFor, menu.ErrorMessage);
                        await AssignList(menu);
                        return View(menu);
                    }
                    return RedirectToAction("Index");
                }
                await AssignList(menu);
                return View(menu);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Menu menu = await WebAPIClient.GetAsync<Menu>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Get?Id=" + Id, Session["AccessToken"].ToString());
            await AssignList(menu);
            return View("Edit", menu);
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menu = await WebAPIClient.PutAsync<Menu>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Edit", menu, Session["AccessToken"].ToString());
                    if (menu.IsError)
                    {
                        ModelState.AddModelError(menu.ErrorMessageFor, menu.ErrorMessage);
                        await AssignList(menu);
                        return View(menu);
                    }
                    return RedirectToAction("Index");
                }
                await AssignList(menu);
                return View(menu);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Menu menu = await WebAPIClient.GetAsync<Menu>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Get?Id=" + Id, Session["AccessToken"].ToString());
            menu = await WebAPIClient.PutAsync<Menu>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/Delete", menu, Session["AccessToken"].ToString());
            return RedirectToAction("Index");
        }

        public async Task AssignList(Menu menu)
        {
            menu.MenuNVList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Menu/GetNVList", Session["AccessToken"].ToString());
            menu.ModuleNVList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIAdministration"], "api/Module/GetNVList", Session["AccessToken"].ToString());
        }
    }
}