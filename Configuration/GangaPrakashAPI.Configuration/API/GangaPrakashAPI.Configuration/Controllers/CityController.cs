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
    public class CityController : ApiController
    {
        [Route("api/City/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<City> cityList = CityList.GetList();
            return Ok(cityList);
        }

        [Route("api/City/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            City city = CityPersister.Get();
            return Ok(city);
        }

        [Route("api/City/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            City city = CityPersister.GetCity(Id);
            return Ok(city);
        }

        [Route("api/City/Create")]
        [HttpPost]
        public IHttpActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                CityPersister cityPersister = CityPersister.GetPersister();
                cityPersister.Insert(city);
                return Ok(city);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/City/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                CityPersister cityPersister = CityPersister.GetPersister();
                cityPersister.Update(city);
                return Ok(city);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/City/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(City city)
        {
            CityPersister cityPersister = CityPersister.GetPersister();
            cityPersister.Delete(city);
            return Ok(city);
        }
    }
}
