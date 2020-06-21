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
    public class RoleMenuPrivilegeList
    {
        public static List<RoleMenuPrivilege> GetListByRoleId(Guid RoleId)
        {
            return FetchByRoleId(RoleId);
        }

        private static List<RoleMenuPrivilege> FetchByRoleId(Guid RoleId)
        {
            IRoleMenuPrivilegeDal IroleMenuPrivilegeDal = new RoleMenuPrivilegeDal();
            List<RoleMenuPrivilege> roleMenuPrivilegeList = new List<RoleMenuPrivilege>();
            foreach (var item in IroleMenuPrivilegeDal.FetchByRoleId(RoleId))
            {
                RoleMenuPrivilege roleMenuPrivilege = new RoleMenuPrivilege
                {
                    Id = item.Id,
                    RoleMenuId = item.RoleMenuId,
                    PrivilegeId = item.PrivilegeId
                };
                roleMenuPrivilegeList.Add(roleMenuPrivilege);
            }
            return roleMenuPrivilegeList;
        }
    }
}
