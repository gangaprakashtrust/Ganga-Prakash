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
    public class CityController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<City> cityList = await WebAPIClient.GetAsync<List<City>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/GetList", Session["AccessToken"].ToString());
            return View(cityList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            City city = await WebAPIClient.GetAsync<City>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/Get", Session["AccessToken"].ToString());
            await AssignList(city);
            return View(city);
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    city = await WebAPIClient.PostAsync<City>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/Create", city, Session["AccessToken"].ToString());
                    if (city.IsError)
                    {
                        ModelState.AddModelError(city.ErrorMessageFor, city.ErrorMessage);
                        await AssignList(city);
                        return View(city);
                    }
                    TempData["Message"] = "City Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(city);
                return View(city);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: City/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            City city = await WebAPIClient.GetAsync<City>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/Get?Id=" + Id, Session["AccessToken"].ToString());
            await AssignList(city);
            return View("Edit", city);
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    city = await WebAPIClient.PutAsync<City>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/Edit", city, Session["AccessToken"].ToString());
                    if (city.IsError)
                    {
                        ModelState.AddModelError(city.ErrorMessageFor, city.ErrorMessage);
                        await AssignList(city);
                        return View(city);
                    }
                    TempData["Message"] = "City Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                await AssignList(city);
                return View(city);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: City/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            City city = await WebAPIClient.GetAsync<City>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/Get?Id=" + Id, Session["AccessToken"].ToString());
            city = await WebAPIClient.PutAsync<City>(ConfigurationManager.AppSettings["APIConfiguration"], "api/City/Delete", city, Session["AccessToken"].ToString());
            if (city.IsError)
            {
                TempData["Message"] = city.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "City Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }

        public async Task AssignList(City city)
        {
            city.CountryNVList = new List<KeyValuePair<Guid, string>>();
            city.CountryNVList = await WebAPIClient.GetAsync<List<KeyValuePair<Guid, String>>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/GetNVList", Session["AccessToken"].ToString());
        }
    }
}