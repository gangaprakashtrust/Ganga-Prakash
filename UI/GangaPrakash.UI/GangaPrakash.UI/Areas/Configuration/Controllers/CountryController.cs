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
    public class CountryController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<Country> countryList = await WebAPIClient.GetAsync<List<Country>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/GetList", Session["AccessToken"].ToString());
            return View(countryList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Country country = await WebAPIClient.GetAsync<Country>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/Get", Session["AccessToken"].ToString());
            return View(country);
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    country = await WebAPIClient.PostAsync<Country>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/Create", country, Session["AccessToken"].ToString());
                    if (country.IsError)
                    {
                        ModelState.AddModelError(country.ErrorMessageFor, country.ErrorMessage);
                        return View(country);
                    }
                    TempData["Message"] = "Country Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(country);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Country/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Country country = await WebAPIClient.GetAsync<Country>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", country);
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    country = await WebAPIClient.PutAsync<Country>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/Edit", country, Session["AccessToken"].ToString());
                    if (country.IsError)
                    {
                        ModelState.AddModelError(country.ErrorMessageFor, country.ErrorMessage);
                        return View(country);
                    }
                    TempData["Message"] = "Country Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(country);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Country/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Country country = await WebAPIClient.GetAsync<Country>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/Get?Id=" + Id, Session["AccessToken"].ToString());
            country = await WebAPIClient.PutAsync<Country>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Country/Delete", country, Session["AccessToken"].ToString());
            if (country.IsError)
            {
                TempData["Message"] = country.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Country Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }
    }
}