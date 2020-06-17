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
    public class RoleMenuList
    {
        public static List<RoleMenu> GetListByRoleId(Guid RoleId)
        {
            return FetchByRoleId(RoleId);
        }

        private static List<RoleMenu> FetchByRoleId(Guid RoleId)
        {
            IRoleMenuDal IroleMenuDal = new RoleMenuDal();
            List<RoleMenu> roleMenuList = new List<RoleMenu>();
            foreach (var item in IroleMenuDal.FetchByRoleId(RoleId))
            {
                RoleMenu roleMenu = new RoleMenu
                {
                    Id = item.Id,
                    RoleId = item.RoleId,
                    MenuId = item.MenuId
                };
                roleMenuList.Add(roleMenu);
            }
            return roleMenuList;
        }
    }
}
