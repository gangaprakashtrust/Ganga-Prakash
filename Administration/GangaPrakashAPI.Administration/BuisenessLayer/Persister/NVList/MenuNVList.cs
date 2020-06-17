using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;

namespace GangaPrakashAPI.Administration.Persister
{
    public static class MenuNVList
    {
        public static List<KeyValuePair<Guid, String>> GetParentListByModuleId(Guid ModuleId)
        {
            return FetchParentListByModuleId(ModuleId);
        }

        private static List<KeyValuePair<Guid, String>> FetchParentListByModuleId(Guid ModuleId)
        {
            IMenuDal ImenuDal = new MenuDal();
            List<KeyValuePair<Guid, String>> menuList = new List<KeyValuePair<Guid, String>>();
            foreach (var item in ImenuDal.GetParentListByModuleId(ModuleId))
            {
                menuList.Add(new KeyValuePair<Guid, string>(item.Id, item.Name));
            }
            return menuList;
        }
    }
}
