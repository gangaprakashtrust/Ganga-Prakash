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
    public class PrivilegePersister
    {
        public Privilege Insert(Privilege role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IPrivilegeDal IroleDal = new PrivilegeDal();
            PrivilegeDto roleDto = new PrivilegeDto
            {
                Name = role.Name,
                IsActive = true
            };
            IroleDal.IsPrivilegeAlreadyPresent(roleDto);
            if (roleDto.ErrorCount == 0)
            {
                IroleDal.Insert(roleDto, con, trans);
                role.Id = roleDto.Id;

            }
            else
            {
                role.IsError = true;
                role.ErrorMessage = roleDto.ErrorMessage;
                role.ErrorMessageFor = "Name";

            }
            return role;
        }

        public Privilege Update(Privilege role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IPrivilegeDal IroleDal = new PrivilegeDal();
            PrivilegeDto roleDto = new PrivilegeDto
            {
                Id = role.Id,
                Name = role.Name,
                IsActive = true
            };
            IroleDal.IsPrivilegeAlreadyPresent(roleDto);
            if (roleDto.ErrorCount == 0)
            {

                IroleDal.Update(roleDto, con, trans);
                role.Id = roleDto.Id;
            }
            else
            {
                role.IsError = true;
                role.ErrorMessage = roleDto.ErrorMessage;
                role.ErrorMessageFor = "Name";

            }
            return role;
        }

        public Privilege Delete(Privilege role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IPrivilegeDal IroleDal = new PrivilegeDal();
            PrivilegeDto roleDto = new PrivilegeDto
            {
                Id = role.Id,
                Name = role.Name,
                IsActive = false
            };
            IroleDal.Delete(roleDto, con, trans);
            role.Id = roleDto.Id;
            return role;
        }

        public static Privilege GetPrivilege(Guid Id)
        {
            IPrivilegeDal IroleDal = new PrivilegeDal();
            PrivilegeDto roleDto = IroleDal.FetchById(Id);
            Privilege role = new Privilege
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
            };
            return role;
        }

        public static Privilege Get()
        {
            Privilege role = new Privilege();
            return role;
        }

        public static PrivilegePersister GetPersister()
        {
            PrivilegePersister rolePersister = new PrivilegePersister();
            return rolePersister;
        }
    }
}
