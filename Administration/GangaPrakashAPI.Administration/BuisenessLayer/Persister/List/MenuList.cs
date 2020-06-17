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
	public class MenuList
	{
		public static List<Menu> GetList()
		{
			return Fetch();
		}

		private static List<Menu> Fetch()
		{
			IMenuDal ImenuDal = new MenuDal();
			List<Menu> menuList = new List<Menu>();
			foreach (var item in ImenuDal.Fetch())
			{
				Menu menu = new Menu
				{
					Id = item.Id,
					Name = item.Name,
					Controller = item.Controller,
					Action = item.Action,
					Area = item.Area,
					ParentId = item.ParentId,
					ModuleId = item.ModuleId,
					SequenceNo = item.SequenceNo,
					Module=item.Module,
					ParentMenu = item.ParentMenu

				};
				menuList.Add(menu);
			}
			return menuList;
		}

        public static List<Menu> GetParentList()
        {
            return FetchParentList();
        }

        private static List<Menu> FetchParentList()
        {
            IMenuDal ImenuDal = new MenuDal();
            List<Menu> menuList = new List<Menu>();
            foreach (var item in ImenuDal.FetchParentList())
            {
                Menu menu = new Menu
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    ModuleId = item.ModuleId,
                    Module = item.Module,
                    IsParent=item.IsParent
                };
                menuList.Add(menu);
            }
            return menuList;
        }

        public static List<Menu> GetParentListByRoleId(Guid RoleId)
        {
            return FetchParentListByRoleId(RoleId);
        }

        private static List<Menu> FetchParentListByRoleId(Guid RoleId)
        {
            IMenuDal ImenuDal = new MenuDal();
            List<Menu> menuList = new List<Menu>();
            foreach (var item in ImenuDal.FetchParentListByRoleId(RoleId))
            {
                Menu menu = new Menu
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    ModuleId = item.ModuleId,
                    Module = item.Module,
                    IsParent = item.IsParent,
                    IsChecked=item.IsChecked
                };
                menuList.Add(menu);
            }
            return menuList;
        }
    }
}
