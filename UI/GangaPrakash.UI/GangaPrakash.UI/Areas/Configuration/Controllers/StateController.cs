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
    public class StateController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<State> stateList = await WebAPIClient.GetAsync<List<State>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/GetList", Session["AccessToken"].ToString());
            return View(stateList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            State state = await WebAPIClient.GetAsync<State>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/Get", Session["AccessToken"].ToString());
            await AssignList(state);
            return View(state);
        }

        // POST: State/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(State state)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    state = await WebAPIClient.PostAsync<State>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/Create", state, Session["AccessToken"].ToString());
                    if (state.IsError)
                    {
                        ModelState.AddModelError(state.ErrorMessageFor, state.ErrorMessage);
                        await AssignList(state);
                        return View(state);
                    }
                    TempData["Message"] = "State Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(state);
                return View(state);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: State/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            State state = await WebAPIClient.GetAsync<State>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/Get?Id=" + Id, Session["AccessToken"].ToString());
            await AssignList(state);
            return View("Edit", state);
        }

        // POST: State/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(State state)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    state = await WebAPIClient.PutAsync<State>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/Edit", state, Session["AccessToken"].ToString());
                    if (state.IsError)
                    {
                        ModelState.AddModelError(state.ErrorMessageFor, state.ErrorMessage);
                        await AssignList(state);
                        return View(state);
                    }
                    TempData["Message"] = "State Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(state);
                return View(state);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: State/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            State state = await WebAPIClient.GetAsync<State>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/Get?Id=" + Id, Session["AccessToken"].ToString());
            state = await WebAPIClient.PutAsync<State>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/Delete", state, Session["AccessToken"].ToString());
            if (state.IsError)
            {
                TempData["Message"] = state.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "State Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetStateListByCountryId(Guid Id)
        {
            List<KeyValuePair<Guid, string>> StateList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/State/GetNVListByCountryId?CountryId=" + Id, Session["AccessToken"].ToString());
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }


        public async Task AssignList(State state)
        {
            state.CountryNVList = new List<KeyValuePair<Guid, string>>();
            state.CountryNVList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/GetNVList", Session["AccessToken"].ToString());
        }
    }
}