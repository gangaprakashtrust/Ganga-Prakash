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
    public class CountryController : ApiController
    {
        [Route("api/Country/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<Country> countryList = CountryList.GetList();
            return Ok(countryList);
        }

        [Route("api/Country/GetNVList")]
        [HttpGet]
        public IHttpActionResult GetNVList()
        {
            List<KeyValuePair<Guid, String>> countryNVList = CountryNVList.GetList();
            return Ok(countryNVList);
        }

        [Route("api/Country/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Country country = CountryPersister.Get();
            return Ok(country);
        }

        [Route("api/Country/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            Country country = CountryPersister.GetCountry(Id);
            return Ok(country);
        }

        [Route("api/Country/Create")]
        [HttpPost]
        public IHttpActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                CountryPersister countryPersister = CountryPersister.GetPersister();
                countryPersister.Insert(country);
                return Ok(country);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Country/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                CountryPersister countryPersister = CountryPersister.GetPersister();
                countryPersister.Update(country);
                return Ok(country);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/Country/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(Country country)
        {
            CountryPersister countryPersister = CountryPersister.GetPersister();
            countryPersister.Delete(country);
            return Ok(country);
        }
    }
}
