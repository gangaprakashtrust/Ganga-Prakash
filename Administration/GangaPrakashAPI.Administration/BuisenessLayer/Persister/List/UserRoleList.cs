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
    public class UserRoleList
    {
        public static List<UserRole> GetListByApplicationUserId(Guid ApplicationUserId)
        {
            return FetchByApplicationUserId(ApplicationUserId);
        }

        private static List<UserRole> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            IUserRoleDal IuserRoleDal = new UserRoleDal();
            List<UserRole> userRoleList = new List<UserRole>();
            foreach (var item in IuserRoleDal.FetchByApplicationUserId(ApplicationUserId))
            {
                UserRole userRole = new UserRole
                {
                    Id = item.Id,
                    ApplicationUserId = item.ApplicationUserId,
                    RoleId = item.RoleId,
                };
                userRoleList.Add(userRole);
            }
            return userRoleList;
        }
    }
}
