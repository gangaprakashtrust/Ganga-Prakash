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
    public class RolePersister
    {
        public Role Insert(Role Role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleDal IRoleDal = new RoleDal();
            RoleDto RoleDto = new RoleDto
            {
                Name = Role.Name,
                IsActive = true
            };
            IRoleDal.IsRoleAlreadyPresent(RoleDto);
            if (RoleDto.ErrorCount == 0)
            {
                IRoleDal.Insert(RoleDto, con, trans);
                    Role.Id = RoleDto.Id;
            
            }
            else
            {
                Role.IsError = true;
                Role.ErrorMessage = RoleDto.ErrorMessage;
                Role.ErrorMessageFor = "Name";

            }
            return Role;
        }

        public Role Update(Role Role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleDal IRoleDal = new RoleDal();
            RoleDto RoleDto = new RoleDto
            {
                Id = Role.Id,
                Name = Role.Name,
                IsActive = true
            };
            IRoleDal.IsRoleAlreadyPresent(RoleDto);
            if (RoleDto.ErrorCount == 0)
            {

                IRoleDal.Update(RoleDto, con, trans);
                Role.Id = RoleDto.Id;
            }
            else
            {
                Role.IsError = true;
                Role.ErrorMessage = RoleDto.ErrorMessage;
                Role.ErrorMessageFor = "Name";

            }
            return Role;
        }

        public Role Delete(Role Role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleDal IRoleDal = new RoleDal();
            RoleDto RoleDto = new RoleDto
            {
                Id = Role.Id,
                Name = Role.Name,
                IsActive = false
            };
            IRoleDal.Delete(RoleDto, con, trans);
            Role.Id = RoleDto.Id;
            return Role;
        }

        public static Role GetRole(Guid Id)
        {
            IRoleDal IRoleDal = new RoleDal();
            RoleDto RoleDto = IRoleDal.FetchById(Id);
            Role Role = new Role
            {
                Id = RoleDto.Id,
                Name = RoleDto.Name,
            };
            return Role;
        }

        public static Role Get()
        {
            Role Role = new Role();
            return Role;
        }

        public static RolePersister GetPersister()
        {
            RolePersister RolePersister = new RolePersister();
            return RolePersister;
        }
    }
}
