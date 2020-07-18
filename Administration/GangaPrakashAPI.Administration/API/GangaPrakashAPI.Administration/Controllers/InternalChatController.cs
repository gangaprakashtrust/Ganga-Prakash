using GangaPrakashAPI.Administration.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Controllers
{
    [Authorize]
    public class InternalChatController : ApiController
    {
        [Route("api/InternalChat/GetListByApplicationUserId")]
        [HttpGet]
        public IHttpActionResult GetListByApplicationUserId(Guid ApplicationUserId)
        {
            List<InternalChat> internalChatList = InternalChatList.GetListByApplicationUserId(ApplicationUserId);
            return Ok(internalChatList);
        }

        [Route("api/InternalChat/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            InternalChat internalChat = InternalChatPersister.Get();
            return Ok(internalChat);
        }

        [Route("api/InternalChat/Create")]
        [HttpPost]
        public IHttpActionResult Create(InternalChat internalChat)
        {
            if (ModelState.IsValid)
            {
                InternalChatPersister internalChatPersister = InternalChatPersister.GetPersister();
                internalChatPersister.Insert(internalChat);
                return Ok(internalChat);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }
    }
}
