using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Persister
{
    public class MenuTransPersister
    {
        public MenuTrans Insert(MenuTrans menuTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                MenuPersister menuPersister = MenuPersister.GetPersister();

                //Now Saving Objects One By One
                menuTrans.menu = menuPersister.Insert(menuTrans.menu, con, trans);
                if (menuTrans.menu.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return menuTrans;
                }

                foreach (var item in menuTrans.privilegeList.Where(a => a.IsChecked))
                {
                    MenuPrivilegePersister menuPrivilegePersister = MenuPrivilegePersister.GetPersister();
                    MenuPrivilege menuPrivilege = MenuPrivilegePersister.Get();
                    menuPrivilege.MenuId = menuTrans.menu.Id;
                    menuPrivilege.PrivilegeId = item.Id;
                    menuPrivilegePersister.Insert(menuPrivilege, con, trans);
                }
                trans.Commit();
                con.Close();
                return menuTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public MenuTrans Update(MenuTrans menuTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                MenuPersister menuPersister = MenuPersister.GetPersister();
                List<MenuPrivilege> menuPrivilegeList = MenuPrivilegeList.GetListByMenuId(menuTrans.menu.Id);

                //Now Saving Objects One By One
                menuTrans.menu = menuPersister.Update(menuTrans.menu, con, trans);
                if (menuTrans.menu.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return menuTrans;
                }

                //Adding and updating new records
                List<Guid> CheckedPrivileged = new List<Guid>();
                foreach (var item in menuTrans.privilegeList.Where(a => a.IsChecked))
                {
                    Boolean IsPrivileAlreadyPresent = (menuPrivilegeList.Where(a => a.PrivilegeId == item.Id && a.MenuId == menuTrans.menu.Id).ToList().Count > 0) ? true : false;
                    if (!IsPrivileAlreadyPresent)
                    {
                        CheckedPrivileged.Add(item.Id);
                    }

                }
                foreach (var item in CheckedPrivileged)
                {
                    MenuPrivilegePersister menuPrivilegePersister = MenuPrivilegePersister.GetPersister();
                    MenuPrivilege menuPrivilege = MenuPrivilegePersister.Get();
                    menuPrivilege.MenuId = menuTrans.menu.Id;
                    menuPrivilege.PrivilegeId = item;
                    menuPrivilegePersister.Insert(menuPrivilege, con, trans);
                }

                //Deleting deleted records
                foreach (var item in menuTrans.privilegeList.Where(a => a.IsChecked==false))
                {
                    if (menuPrivilegeList.Where(a => a.PrivilegeId==item.Id).ToList().Count > 0)
                    {
                        MenuPrivilegePersister menuPrivilegePersister = MenuPrivilegePersister.GetPersister();
                        menuPrivilegePersister.Delete(menuPrivilegeList.Where(a => a.PrivilegeId.Equals(item.Id)).FirstOrDefault(), con, trans);
                    }
                }
                trans.Commit();
                con.Close();
                return menuTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public MenuTrans Delete(MenuTrans menuTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                MenuPersister menuPersister = MenuPersister.GetPersister();
                MenuPrivilegePersister menuPrivilegePersister = MenuPrivilegePersister.GetPersister();

                //Now Saving Objects One By One
                menuPersister.Delete(menuTrans.menu, con, trans);
                if (menuTrans.menu.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return menuTrans;
                }
                menuPrivilegePersister.Delete(menuTrans.menu, con, trans);
                if (menuTrans.menu.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return menuTrans;
                }
                trans.Commit();
                con.Close();
                return menuTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public static MenuTrans GetMenuTrans(Guid Id)
        {
            MenuTrans menuTrans = MenuTransPersister.Get();
            menuTrans.menu = MenuPersister.GetMenu(Id);
            menuTrans.privilegeList = PrivilegeList.GetListByMenuId(Id);
            return menuTrans;
        }

        public static MenuTrans Get()
        {
            MenuTrans menuTrans = new MenuTrans();
            menuTrans.menu = MenuPersister.Get();
            menuTrans.privilegeList = PrivilegeList.GetList();
            return menuTrans;
        }

        public static MenuTransPersister GetPersister()
        {
            MenuTransPersister MenuTransPersister = new MenuTransPersister();
            return MenuTransPersister;
        }
    }
}
