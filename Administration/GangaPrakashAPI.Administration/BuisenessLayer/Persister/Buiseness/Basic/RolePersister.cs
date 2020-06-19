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
        public Role Insert(Role role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleDal IroleDal = new RoleDal();
            RoleDto roleDto = new RoleDto
            {
                Name = role.Name,
                IsActive = true
            };
            IroleDal.IsRoleAlreadyPresent(roleDto);
            if (roleDto.ErrorCount == 0)
            {
                IroleDal.Insert(roleDto, con, trans);
                role.Id = roleDto.Id;

            }
            else
            {
                role.IsError = true;
                role.ErrorMessage = roleDto.ErrorMessage;
                role.ErrorMessageFor = "role.Name";

            }
            return role;
        }

        public Role Update(Role role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleDal IroleDal = new RoleDal();
            RoleDto roleDto = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                IsActive = true
            };
            IroleDal.IsRoleAlreadyPresent(roleDto);
            if (roleDto.ErrorCount == 0)
            {

                IroleDal.Update(roleDto, con, trans);
                role.Id = roleDto.Id;
            }
            else
            {
                role.IsError = true;
                role.ErrorMessage = roleDto.ErrorMessage;
                role.ErrorMessageFor = "role.Name";

            }
            return role;
        }

        public Role Delete(Role role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleDal IroleDal = new RoleDal();
            RoleDto roleDto = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                IsActive = false
            };
            IroleDal.Delete(roleDto, con, trans);
            role.Id = roleDto.Id;
            return role;
        }

        public static Role GetRole(Guid Id)
        {
            IRoleDal IroleDal = new RoleDal();
            RoleDto roleDto = IroleDal.FetchById(Id);
            Role role = new Role
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
            };
            return role;
        }

        public static Role Get()
        {
            Role role = new Role();
            return role;
        }

        public static RolePersister GetPersister()
        {
            RolePersister rolePersister = new RolePersister();
            return rolePersister;
        }
    }
}
