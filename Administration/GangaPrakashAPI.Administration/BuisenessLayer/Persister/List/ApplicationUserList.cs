using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Administration.Dal;


namespace GangaPrakashAPI.Administration.Persister
{
    public class ApplicationUserList
    {
        public static List<ApplicationUser> GetList()
        {
            return Fetch();
        }

        private static List<ApplicationUser> Fetch()
        {
            IApplicationUserDal IapplicationUserDal = new ApplicationUserDal();
            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            foreach (var item in IapplicationUserDal.Fetch())
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    UserName = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    ShortName = item.ShortName,
                    MobileNo = item.MobileNo,
                    IsDoctor = item.IsDoctor
                };
                applicationUserList.Add(applicationUser);
            }
            return applicationUserList;
        }
    }
}
