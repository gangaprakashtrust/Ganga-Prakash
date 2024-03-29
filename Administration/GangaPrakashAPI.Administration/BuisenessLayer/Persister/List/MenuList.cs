﻿using GangaPrakashAPI.Model;
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

        public static List<MenuHelper> GetParentList()
        {
            return FetchParentList();
        }

        private static List<MenuHelper> FetchParentList()
        {
            IMenuDal ImenuDal = new MenuDal();
            List<MenuHelper> menuList = new List<MenuHelper>();
            foreach (var item in ImenuDal.FetchParentList())
            {
                MenuHelper menu = new MenuHelper
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    ModuleId = item.ModuleId,
                    Module = item.Module,
                    IsParent=item.IsParent,
                    SequenceNo = item.SequenceNo,
                };
                menuList.Add(menu);
            }
            return menuList;
        }

        public static List<MenuHelper> GetParentListByRoleId(Guid RoleId)
        {
            return FetchParentListByRoleId(RoleId);
        }

        private static List<MenuHelper> FetchParentListByRoleId(Guid RoleId)
        {
            IMenuDal ImenuDal = new MenuDal();
            List<MenuHelper> menuList = new List<MenuHelper>();
            foreach (var item in ImenuDal.FetchParentListByRoleId(RoleId))
            {
                MenuHelper menu = new MenuHelper
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    ModuleId = item.ModuleId,
                    Module = item.Module,
                    IsParent = item.IsParent,
                    IsChecked=item.IsChecked,
                    SequenceNo = item.SequenceNo
                };
                menuList.Add(menu);
            }
            return menuList;
        }

        public static List<UserAccessMenu> GetListByApplicationUserId(Guid ApplicationUserId)
        {
            return FetchByApplicationUserId(ApplicationUserId);
        }

        private static List<UserAccessMenu> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            IMenuDal ImenuDal = new MenuDal();
            List<UserAccessMenu> menuList = new List<UserAccessMenu>();
            foreach (var item in ImenuDal.FetchByApplicationUserId(ApplicationUserId))
            {
                UserAccessMenu menu = new UserAccessMenu
                {
                    Id = item.Id,
                    Action = item.Action,
                    Controller = item.Controller,
                    Area = item.Area,
                    Name = item.Name,
                    Module = item.Module,
                    ModuleId = item.ModuleId,
                    SequenceNo = item.SequenceNo,
                    ParentId = item.ParentId,
                    IsParent = item.IsParent,
                    ModuleSequenceNo=item.ModuleSequenceNo
                };
                menuList.Add(menu);
            }
            return menuList;
        }

        public static List<Menu> GetUserMenuBasedOnPrivilege(String Controller,String Action, String Area,Guid ApplicationUserId)
        {
            return FetchUserMenuBasedOnPrivilege(Controller, Action, Area, ApplicationUserId);
        }

        private static List<Menu> FetchUserMenuBasedOnPrivilege(String Controller, String Action, String Area, Guid ApplicationUserId)
        {
            IMenuDal ImenuDal = new MenuDal();
            List<Menu> menuList = new List<Menu>();
            foreach (var item in ImenuDal.FetchUserMenuBasedOnPrivilege(Controller, Action, Area, ApplicationUserId))
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
                    Module = item.Module,
                    ParentMenu = item.ParentMenu

                };
                menuList.Add(menu);
            }
            return menuList;
        }
    }
}
