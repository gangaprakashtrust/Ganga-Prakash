using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Persister
{
    public class UserRolePersister
    {
        public UserRole Insert(UserRole userRole, SqlConnection con = null, SqlTransaction trans = null)
        {
            IUserRoleDal IuserRoleDal = new UserRoleDal();
            UserRoleDto userRoleDto = new UserRoleDto
            {
                ApplicationUserId = userRole.ApplicationUserId,
                RoleId = userRole.RoleId,
                IsActive = true
            };
            IuserRoleDal.Insert(userRoleDto, con, trans);
            userRole.Id = userRoleDto.Id;
            return userRole;
        }

        public UserRole Update(UserRole userRole, SqlConnection con = null, SqlTransaction trans = null)
        {
            IUserRoleDal IuserRoleDal = new UserRoleDal();
            UserRoleDto userRoleDto = new UserRoleDto
            {
                Id = userRole.Id,
                ApplicationUserId = userRole.ApplicationUserId,
                RoleId = userRole.RoleId,
                IsActive = true
            };
            IuserRoleDal.Update(userRoleDto, con, trans);
            userRole.Id = userRoleDto.Id;
            return userRole;
        }

        public UserRole Delete(UserRole userRole, SqlConnection con = null, SqlTransaction trans = null)
        {
            IUserRoleDal IuserRoleDal = new UserRoleDal();
            UserRoleDto userRoleDto = new UserRoleDto
            {
                Id = userRole.Id,
                IsActive = false
            };
            IuserRoleDal.Delete(userRoleDto, con, trans);
            userRole.Id = userRoleDto.Id;

            return userRole;
        }
        public void Delete(ApplicationUser applicationUser, SqlConnection con = null, SqlTransaction trans = null)
        {
            IUserRoleDal IuserRoleDal = new UserRoleDal();
            ApplicationUserDto userRoleDto = new ApplicationUserDto
            {
                Id = applicationUser.Id,
                IsActive = false
            };
            IuserRoleDal.Delete(userRoleDto, con, trans);
        }

        public static UserRole GetUserRole(Guid Id)
        {
            IUserRoleDal IuserRoleDal = new UserRoleDal();
            UserRoleDto userRoleDto = IuserRoleDal.FetchById(Id);
            UserRole userRole = new UserRole
            {
                Id = userRoleDto.Id,
                ApplicationUserId = userRoleDto.ApplicationUserId,
                RoleId = userRoleDto.RoleId
            };
            return userRole;
        }

        public static UserRole Get()
        {
            UserRole userRole = new UserRole();
            return userRole;
        }

        public static UserRolePersister GetPersister()
        {
            UserRolePersister userRolePersister = new UserRolePersister();
            return userRolePersister;
        }
    }
}
