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
    public class RoleMenuPersister
    {
        public RoleMenu Insert(RoleMenu roleMenu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuDal IroleMenuDal = new RoleMenuDal();
            RoleMenuDto roleMenuDto = new RoleMenuDto
            {
                RoleId = roleMenu.RoleId,
                MenuId = roleMenu.MenuId,
                IsActive = true
            };
            IroleMenuDal.Insert(roleMenuDto, con, trans);
            roleMenu.Id = roleMenuDto.Id;
            return roleMenu;
        }

        public RoleMenu Update(RoleMenu roleMenu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuDal IroleMenuDal = new RoleMenuDal();
            RoleMenuDto roleMenuDto = new RoleMenuDto
            {
                Id = roleMenu.Id,
                RoleId = roleMenu.RoleId,
                MenuId = roleMenu.MenuId,
                IsActive = true
            };
            IroleMenuDal.Insert(roleMenuDto, con, trans);
            roleMenu.Id = roleMenuDto.Id;
            return roleMenu;
        }

        public RoleMenu Delete(RoleMenu roleMenu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuDal IroleMenuDal = new RoleMenuDal();
            RoleMenuDto roleMenuDto = new RoleMenuDto
            {
                Id = roleMenu.Id,
                IsActive = false
            };
            IroleMenuDal.Delete(roleMenuDto, con, trans);
            roleMenu.Id = roleMenuDto.Id;
            return roleMenu;
        }

        public Role Delete(Role role, SqlConnection con = null, SqlTransaction trans = null)
        {
            IRoleMenuDal IroleMenuDal = new RoleMenuDal();
            RoleMenuDto roleMenuDto = new RoleMenuDto
            {
                RoleId = role.Id,
                IsActive = false
            };
            IroleMenuDal.DeleteRoleMenuByRole(roleMenuDto, con, trans);
            return role;
        }

        public static RoleMenu Get()
        {
            RoleMenu roleMenu = new RoleMenu();
            return roleMenu;
        }

        public static RoleMenuPersister GetPersister()
        {
            RoleMenuPersister roleMenuPersister = new RoleMenuPersister();
            return roleMenuPersister;
        }
    }
}
