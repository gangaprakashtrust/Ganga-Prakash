using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using GangaPrakashAPI.Administration.Models;
using GangaPrakashAPI.Administration.Providers;
using GangaPrakashAPI.Administration.Results;
using GangaPrakashAPI.Model;
using GangaPrakashAPI.Administration.Persister;
using System.Net;
using ApplicationUser = GangaPrakashAPI.Model.ApplicationUser;

namespace GangaPrakashAPI.Administration.Controllers
{
    [Authorize]
    public class ApplicationUserController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public ApplicationUserController()
        {
        }

        public ApplicationUserController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        #region Helpers

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        [Route("api/ApplicationUser/GetList")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            List<ApplicationUser> applicationUserList = ApplicationUserList.GetList();
            return Ok(applicationUserList);
        }

        [Route("api/ApplicationUser/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ApplicationUserTrans applicationUserTrans = ApplicationUserTransPersister.Get();
            return Ok(applicationUserTrans);
        }

        [Route("api/ApplicationUser/Get")]
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            ApplicationUserTrans applicationUserTrans = ApplicationUserTransPersister.GetApplicationUserTrans(Id);
            return Ok(applicationUserTrans);
        }

        // POST api/Account/Register
        [Route("api/ApplicationUser/Create")]
        public async Task<IHttpActionResult> Create(ApplicationUserTrans applicationUserTrans)
        {
            if (ModelState.IsValid)
            {
                var user = new GangaPrakashAPI.Administration.Models.ApplicationUser() { UserName = applicationUserTrans.applicationUser.UserName, Email = applicationUserTrans.applicationUser.Email };

                IdentityResult result = await UserManager.CreateAsync(user, applicationUserTrans.applicationUser.Password);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                GangaPrakashAPI.Administration.Models.ApplicationUser applicationUser = await UserManager.FindByEmailAsync(applicationUserTrans.applicationUser.Email);
                applicationUserTrans.applicationUser.UserId = Guid.Parse(applicationUser.Id);
                ApplicationUserTransPersister applicationUserTransPersister = ApplicationUserTransPersister.GetPersister();
                applicationUserTransPersister.Insert(applicationUserTrans);
                return Ok(applicationUserTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/ApplicationUser/Edit")]
        [HttpPut]
        public IHttpActionResult Edit(ApplicationUserTrans applicationUserTrans)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserTransPersister applicationUserTransPersister = ApplicationUserTransPersister.GetPersister();
                applicationUserTransPersister.Update(applicationUserTrans);
                return Ok(applicationUserTrans);
            }
            return Content(HttpStatusCode.ExpectationFailed, "Invalid data");
        }

        [Route("api/ApplicationUser/Delete")]
        [HttpPut]
        public IHttpActionResult Delete(ApplicationUserTrans applicationUserTrans)
        {
            ApplicationUserTransPersister applicationUserTransPersister = ApplicationUserTransPersister.GetPersister();
            applicationUserTransPersister.Delete(applicationUserTrans);
            return Ok(applicationUserTrans);
        }
        #endregion
    }
}
