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
    public class MenuPrivilegeList
    {
        public static List<MenuPrivilege> GetListByMenuId(Guid MenuId)
        {
            return FetchByMenuId(MenuId);
        }

        private static List<MenuPrivilege> FetchByMenuId(Guid MenuId)
        {
            IMenuPrivilegeDal ImenuPrivilegeDal = new MenuPrivilegeDal();
            List<MenuPrivilege> menuPrivilegeList = new List<MenuPrivilege>();
            foreach (var item in ImenuPrivilegeDal.FetchByMenuId(MenuId))
            {
                MenuPrivilege menuPrivilege = new MenuPrivilege
                {
                    Id = item.Id,
                    MenuId = item.MenuId,
                    PrivilegeId = item.PrivilegeId
                };
                menuPrivilegeList.Add(menuPrivilege);
            }
            return menuPrivilegeList;
        }
    }
}
