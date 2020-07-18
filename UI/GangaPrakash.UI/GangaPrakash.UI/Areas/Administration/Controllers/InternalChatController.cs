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
    public class InternalChatController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            Guid ApplicationUserId = Guid.Parse(Session["ApplicationUserId"].ToString());
            List<InternalChat> internalChatList = await WebAPIClient.GetAsync<List<InternalChat>>(ConfigurationManager.AppSettings["APIAdministration"], "api/InternalChat/GetListByApplicationUserId?ApplicationUserId="+ ApplicationUserId, Session["AccessToken"].ToString());
            return View(internalChatList);
        }
       

        // POST: InternalChat/Create
        [HttpPost]
        public async Task<ActionResult> Create(InternalChat internalChat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    internalChat = await WebAPIClient.PostAsync<InternalChat>(ConfigurationManager.AppSettings["APIAdministration"], "api/InternalChat/Create", internalChat, Session["AccessToken"].ToString());
                    return Json("Ok");
                }
                return Json("Error");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }
    }
}