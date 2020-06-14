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
    public class MenuPrivilegePersister
    {
        public MenuPrivilege Insert(MenuPrivilege menuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuPrivilegeDal ImenuPrivilegeDal = new MenuPrivilegeDal();
            MenuPrivilegeDto menuPrivilegeDto = new MenuPrivilegeDto
            {
                MenuId = menuPrivilege.MenuId,
                PrivilegeId = menuPrivilege.PrivilegeId,
                IsActive = true
            };
            ImenuPrivilegeDal.Insert(menuPrivilegeDto, con, trans);
            menuPrivilege.Id = menuPrivilegeDto.Id;
            return menuPrivilege;
        }

        public MenuPrivilege Update(MenuPrivilege menuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuPrivilegeDal ImenuPrivilegeDal = new MenuPrivilegeDal();
            MenuPrivilegeDto menuPrivilegeDto = new MenuPrivilegeDto
            {
                Id = menuPrivilege.Id,
                MenuId = menuPrivilege.MenuId,
                PrivilegeId = menuPrivilege.PrivilegeId,
                IsActive = true
            };
            ImenuPrivilegeDal.Insert(menuPrivilegeDto, con, trans);
            menuPrivilege.Id = menuPrivilegeDto.Id;
            return menuPrivilege;
        }

        public MenuPrivilege Delete(MenuPrivilege menuPrivilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuPrivilegeDal ImenuPrivilegeDal = new MenuPrivilegeDal();
            MenuPrivilegeDto menuPrivilegeDto = new MenuPrivilegeDto
            {
                Id = menuPrivilege.Id,
                IsActive = false
            };
            ImenuPrivilegeDal.Delete(menuPrivilegeDto, con, trans);
            menuPrivilege.Id = menuPrivilegeDto.Id;
            return menuPrivilege;
        }

        public Menu Delete(Menu menu, SqlConnection con = null, SqlTransaction trans = null)
        {
            IMenuPrivilegeDal ImenuPrivilegeDal = new MenuPrivilegeDal();
            MenuPrivilegeDto menuPrivilegeDto = new MenuPrivilegeDto
            {
                MenuId = menu.Id,
                IsActive = false
            };
            ImenuPrivilegeDal.DeletePrivilegeByMenu(menuPrivilegeDto, con, trans);
            return menu;
        }

        public static MenuPrivilege Get()
        {
            MenuPrivilege menuPrivilege = new MenuPrivilege();
            return menuPrivilege;
        }

        public static MenuPrivilegePersister GetPersister()
        {
            MenuPrivilegePersister menuPrivilegePersister = new MenuPrivilegePersister();
            return menuPrivilegePersister;
        }
    }
}
