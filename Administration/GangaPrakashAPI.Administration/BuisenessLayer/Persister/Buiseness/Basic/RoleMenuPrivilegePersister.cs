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
    public class RoleMenuPrivilegePersister
    {
        public RoleMenuPrivilege Insert(RoleMenuPrivilege roleMenuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            RoleMenuPrivilegeDto roleMenuPrivilegeDto = new RoleMenuPrivilegeDto
            {
                RoleMenuId = roleMenuPrivilege.RoleMenuId,
                PrivilegeId = roleMenuPrivilege.PrivilegeId,
                IsActive = true
            };
            IroleMenuPrivilegeDal.Insert(roleMenuPrivilegeDto, con, trans);
            roleMenuPrivilege.Id = roleMenuPrivilegeDto.Id;
            return roleMenuPrivilege;
        }

        public RoleMenuPrivilege Update(RoleMenuPrivilege roleMenuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            RoleMenuPrivilegeDto roleMenuPrivilegeDto = new RoleMenuPrivilegeDto
            {
                Id = roleMenuPrivilege.Id,
                RoleMenuId = roleMenuPrivilege.RoleMenuId,
                PrivilegeId = roleMenuPrivilege.PrivilegeId,
                IsActive = true
            };
            IroleMenuPrivilegeDal.Insert(roleMenuPrivilegeDto, con, trans);
            roleMenuPrivilege.Id = roleMenuPrivilegeDto.Id;
            return roleMenuPrivilege;
        }

        public RoleMenuPrivilege Delete(RoleMenuPrivilege roleMenuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            RoleMenuPrivilegeDto roleMenuPrivilegeDto = new RoleMenuPrivilegeDto
            {
                Id = roleMenuPrivilege.Id,
                IsActive = false
            };
            IroleMenuPrivilegeDal.Delete(roleMenuPrivilegeDto, con, trans);
            roleMenuPrivilege.Id = roleMenuPrivilegeDto.Id;
            return roleMenuPrivilege;
        }

        public static RoleMenuPrivilege Get()
        {
            RoleMenuPrivilege roleMenuPrivilege = new RoleMenuPrivilege();
            return roleMenuPrivilege;
        }

        public static RoleMenuPrivilegePersister GetPersister()
        {
            RoleMenuPrivilegePersister roleMenuPrivilegePersister = new RoleMenuPrivilegePersister();
            return roleMenuPrivilegePersister;
        }
    }
}
