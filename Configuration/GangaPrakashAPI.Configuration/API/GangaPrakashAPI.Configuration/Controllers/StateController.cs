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
    public class StateController : ApiController
    {
        [Route("api/State/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<State> stateList = StateList.GetList();
            return Ok(stateList);
        }

        [Route("api/State/GetNVList")]
        [HttpGet]
        public IHttpActionResult GetNVList()
        {
            List<KeyValuePair<Guid, String>> stateNVList = StateNVList.GetList();
            return Ok(stateNVList);
        }

        [Route("api/State/GetNVListByCountryId")]
        [HttpGet]
        public IHttpActionResult GetNVListByCountryId(Guid CountryId)
        {
            List<KeyValuePair<Guid, String>> stateNVList = StateNVList.GetListByCountryId(CountryId);
            return Ok(stateNVList);
        }

        [Route("api/State/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            State state = StatePersister.Get();
            return Ok(state);
        }

        [Route("api/State/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            State state = StatePersister.GetState(Id);
            return Ok(state);
        }

        [Route("api/State/Create")]
        [HttpPost]
        public IHttpActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                StatePersister statePersister = StatePersister.GetPersister();
                statePersister.Insert(state);
                return Ok(state);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/State/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                StatePersister statePersister = StatePersister.GetPersister();
                statePersister.Update(state);
                return Ok(state);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/State/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(State state)
        {
            StatePersister statePersister = StatePersister.GetPersister();
            statePersister.Delete(state);
            return Ok(state);
        }
    }
}
