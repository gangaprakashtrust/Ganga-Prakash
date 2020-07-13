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

        public MenuPrivilege Delete(MenuPrivilege menuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            Boolean IsDeleted=IroleMenuPrivilegeDal.Delete(menuPrivilege.MenuId,menuPrivilege.PrivilegeId, con, trans);
            if(!IsDeleted)
            {
                menuPrivilege.IsError = true;
                menuPrivilege.ErrorMessage = "Please try again!";
                menuPrivilege.ErrorMessageFor = "menu.Name";
            }
            return menuPrivilege;
        }

        public Role Delete(Role role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            Boolean IsDeleted = IroleMenuPrivilegeDal.Delete(role.Id, con, trans);
            if (!IsDeleted)
            {
                role.IsError = true;
                role.ErrorMessage = "Please try again!";
                role.ErrorMessageFor = "role.Name";
            }
            return role;
        }

        public RoleMenu Delete(RoleMenu roleMenu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            Boolean IsDeleted = IroleMenuPrivilegeDal.Delete(roleMenu.RoleId, roleMenu.MenuId, roleMenu.Id, con, trans);
            if (!IsDeleted)
            {
                roleMenu.IsError = true;
                roleMenu.ErrorMessage = "Please try again!";
                roleMenu.ErrorMessageFor = "role.Name";
            }
            return roleMenu;
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
