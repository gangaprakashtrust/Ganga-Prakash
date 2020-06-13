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
	}
}
