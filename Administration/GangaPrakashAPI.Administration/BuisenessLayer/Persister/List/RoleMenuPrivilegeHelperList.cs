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
    public class RoleMenuPrivilegeHelperList
    {
        public static List<RoleMenuPrivilegeHelper> GetListByRoleId(Guid RoleId)
        {
            return FetchListByRoleId(RoleId);
        }

        private static List<RoleMenuPrivilegeHelper> FetchListByRoleId(Guid RoleId)
        {
            IRoleMenuPrivilegeHelperDal IroleMenuPrivilegeHelperDal = new RoleMenuPrivilegeHelperDal();
            List<RoleMenuPrivilegeHelper> roleMenuPrivilegeHelperList = new List<RoleMenuPrivilegeHelper>();
            foreach (var item in IroleMenuPrivilegeHelperDal.FetchByRoleId(RoleId))
            {
                RoleMenuPrivilegeHelper roleMenuPrivilegeHelper = new RoleMenuPrivilegeHelper
                {
                    PrivilegeId = item.PrivilegeId,
                    IsChecked = item.IsChecked,
                    Menu = item.Menu,
                    Module = item.Module,
                    Name = item.Name,
                    ModuleId = item.ModuleId,
                    MenuId = item.MenuId,
                    RoleMenuId = item.RoleMenuId,
                    MenuSequenceNo = item.MenuSequenceNo,
                    PrivilegeSequenceNo = item.PrivilegeSequenceNo,
                };
                roleMenuPrivilegeHelperList.Add(roleMenuPrivilegeHelper);
            }
            return roleMenuPrivilegeHelperList;
        }
    }
}
