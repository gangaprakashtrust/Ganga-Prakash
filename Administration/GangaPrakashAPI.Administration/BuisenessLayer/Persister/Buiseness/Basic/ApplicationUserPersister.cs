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
    public class ApplicationUserPersister
    {
        public ApplicationUser Insert(ApplicationUser applicationUser, SqlConnection con = null, SqlTransaction trans = null)
        {
            IApplicationUserDal IapplicationUserDal = new ApplicationUserDal();
            ApplicationUserDto applicationUserDto = new ApplicationUserDto
            {
                UserId = applicationUser.UserId,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                ShortName = applicationUser.ShortName,
                MobileNo = applicationUser.MobileNo,
                ImagePath = applicationUser.ImagePath,
                IsDoctor = applicationUser.IsDoctor,
                IsActive = true
            };
            IapplicationUserDal.Insert(applicationUserDto, con, trans);
            applicationUser.Id = applicationUserDto.Id;
            return applicationUser;
        }

        public ApplicationUser Update(ApplicationUser applicationUser, SqlConnection con = null, SqlTransaction trans = null)
        {
            IApplicationUserDal IapplicationUserDal = new ApplicationUserDal();
            ApplicationUserDto applicationUserDto = new ApplicationUserDto
            {
                Id = applicationUser.Id,
                UserId = applicationUser.UserId,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                ShortName = applicationUser.ShortName,
                MobileNo = applicationUser.MobileNo,
                ImagePath = applicationUser.ImagePath,
                IsDoctor = applicationUser.IsDoctor,
                IsActive = true
            };
            IapplicationUserDal.Update(applicationUserDto, con, trans);
            return applicationUser;
        }

        public ApplicationUser Delete(ApplicationUser applicationUser, SqlConnection con = null, SqlTransaction trans = null)
        {
            IApplicationUserDal IapplicationUserDal = new ApplicationUserDal();
            ApplicationUserDto applicationUserDto = new ApplicationUserDto
            {
                Id = applicationUser.Id,
                UserId = applicationUser.UserId,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                ShortName = applicationUser.ShortName,
                MobileNo = applicationUser.MobileNo,
                ImagePath = applicationUser.ImagePath,
                IsDoctor = applicationUser.IsDoctor,
                IsActive = false
            };
            IapplicationUserDal.Delete(applicationUserDto, con, trans);
            applicationUser.Id = applicationUserDto.Id;
            return applicationUser;
        }

        public static ApplicationUser GetApplicationUser(Guid Id)
        {
            IApplicationUserDal IapplicationUserDal = new ApplicationUserDal();
            ApplicationUserDto applicationUserDto = IapplicationUserDal.FetchById(Id);
            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = applicationUserDto.Id,
                UserId = applicationUserDto.UserId,
                UserName = applicationUserDto.UserName,
                FirstName = applicationUserDto.FirstName,
                LastName = applicationUserDto.LastName,
                Email = applicationUserDto.Email,
                ShortName = applicationUserDto.ShortName,
                MobileNo = applicationUserDto.MobileNo,
                ImagePath = applicationUserDto.ImagePath,
                IsDoctor = applicationUserDto.IsDoctor,
            };
            return applicationUser;
        }

        public static ApplicationUser Get()
        {
            ApplicationUser applicationUser = new ApplicationUser();
            return applicationUser;
        }

        public static ApplicationUserPersister GetPersister()
        {
            ApplicationUserPersister applicationUserPersister = new ApplicationUserPersister();
            return applicationUserPersister;
        }

        public static String GetApplicationUserIdBySystemUserId(Guid SystemUserId)
        {
            IApplicationUserDal IapplicationUserDal = new ApplicationUserDal();
            return IapplicationUserDal.GetApplicationUserIdBySystemUserId(SystemUserId);
        }
    }
}
