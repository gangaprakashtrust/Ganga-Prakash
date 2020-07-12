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
    public class RoleTransPersister
    {
        public RoleTrans Insert(RoleTrans roleTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                RolePersister rolePersister = RolePersister.GetPersister();

                //Now Saving Objects One By One
                roleTrans.role = rolePersister.Insert(roleTrans.role, con, trans);
                if (roleTrans.role.IsError)
                {
                    roleTrans.IsError = true;
                    roleTrans.ErrorMessage = roleTrans.role.ErrorMessage;
                    roleTrans.ErrorMessageFor = roleTrans.role.ErrorMessageFor;
                    trans.Rollback();
                    con.Close();
                    return roleTrans;
                }

                foreach (var item in roleTrans.menuList.Where(a => a.IsChecked))
                {
                    RoleMenuPersister roleMenuPersister = RoleMenuPersister.GetPersister();
                    RoleMenu roleMenu = RoleMenuPersister.Get();
                    roleMenu.RoleId = roleTrans.role.Id;
                    roleMenu.MenuId = item.Id;
                    roleMenuPersister.Insert(roleMenu, con, trans);
                    if (roleMenu.IsError)
                    {
                        roleTrans.IsError = true;
                        roleTrans.ErrorMessage = roleMenu.ErrorMessage;
                        roleTrans.ErrorMessageFor = roleMenu.ErrorMessageFor;
                        trans.Rollback();
                        con.Close();
                        return roleTrans;
                    }
                }
                trans.Commit();
                con.Close();
                return roleTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public RoleTrans Update(RoleTrans roleTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                RolePersister rolePersister = RolePersister.GetPersister();
                List<RoleMenu> roleMenuList = RoleMenuList.GetListByRoleId(roleTrans.role.Id);

                //Now Saving Objects One By One
                roleTrans.role = rolePersister.Update(roleTrans.role, con, trans);
                if (roleTrans.role.IsError)
                {
                    roleTrans.IsError = true;
                    roleTrans.ErrorMessage = roleTrans.role.ErrorMessage;
                    roleTrans.ErrorMessageFor = roleTrans.role.ErrorMessageFor;
                    trans.Rollback();
                    con.Close();
                    return roleTrans;
                }

                //Adding and updating new records
                List<Guid> CheckedMenuId = new List<Guid>();
                foreach (var item in roleTrans.menuList.Where(a => a.IsChecked))
                {
                    Boolean IsPrivilegeAlreadyPresent = (roleMenuList.Where(a => a.MenuId == item.Id && a.RoleId == roleTrans.role.Id).ToList().Count > 0) ? true : false;
                    if (!IsPrivilegeAlreadyPresent)
                    {
                        CheckedMenuId.Add(item.Id);
                    }

                }
                foreach (var item in CheckedMenuId)
                {
                    RoleMenuPersister roleMenuPersister = RoleMenuPersister.GetPersister();
                    RoleMenu roleMenu = RoleMenuPersister.Get();
                    roleMenu.RoleId = roleTrans.role.Id;
                    roleMenu.MenuId = item;
                    roleMenuPersister.Insert(roleMenu, con, trans);
                    if (roleMenu.IsError)
                    {
                        roleTrans.IsError = true;
                        roleTrans.ErrorMessage = roleMenu.ErrorMessage;
                        roleTrans.ErrorMessageFor = roleMenu.ErrorMessageFor;
                        trans.Rollback();
                        con.Close();
                        return roleTrans;
                    }
                }

                //Deleting deleted records
                foreach (var item in roleTrans.menuList.Where(a => a.IsChecked == false))
                {
                    if (roleMenuList.Where(a => a.MenuId == item.Id).ToList().Count > 0)
                    {
                        RoleMenuPrivilegePersister roleMenuPrivilegePersister = RoleMenuPrivilegePersister.GetPersister();
                        RoleMenu roleMenu = roleMenuList.Where(a => a.MenuId.Equals(item.Id)).FirstOrDefault();
                        roleMenuPrivilegePersister.Delete(roleMenu, con, trans);
                        if (roleMenu.IsError)
                        {
                            roleTrans.IsError = true;
                            roleTrans.ErrorMessage = roleMenu.ErrorMessage;
                            roleTrans.ErrorMessageFor = roleMenu.ErrorMessageFor;
                            trans.Rollback();
                            con.Close();
                            return roleTrans;
                        }

                        RoleMenuPersister roleMenuPersister = RoleMenuPersister.GetPersister();
                        roleMenuPersister.Delete(roleMenu, con, trans);
                        if (roleMenu.IsError)
                        {
                            roleTrans.IsError = true;
                            roleTrans.ErrorMessage = roleMenu.ErrorMessage;
                            roleTrans.ErrorMessageFor = roleMenu.ErrorMessageFor;
                            trans.Rollback();
                            con.Close();
                            return roleTrans;
                        }
                    }
                }
                trans.Commit();
                con.Close();
                return roleTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public RoleTrans Delete(RoleTrans roleTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                RolePersister rolePersister = RolePersister.GetPersister();
                RoleMenuPersister roleMenuPersister = RoleMenuPersister.GetPersister();
                RoleMenuPrivilegePersister roleMenuPrivilegePersister = RoleMenuPrivilegePersister.GetPersister();

                roleMenuPrivilegePersister.Delete(roleTrans.role, con, trans);
                if (roleTrans.role.IsError)
                {
                    roleTrans.IsError = true;
                    roleTrans.ErrorMessage = roleTrans.role.ErrorMessage;
                    roleTrans.ErrorMessageFor = roleTrans.role.ErrorMessageFor;
                    trans.Rollback();
                    con.Close();
                    return roleTrans;
                }

                roleMenuPersister.Delete(roleTrans.role, con, trans);
                if (roleTrans.role.IsError)
                {
                    roleTrans.IsError = true;
                    roleTrans.ErrorMessage = roleTrans.role.ErrorMessage;
                    roleTrans.ErrorMessageFor = roleTrans.role.ErrorMessageFor;
                    trans.Rollback();
                    con.Close();
                    return roleTrans;
                }

                //Now Saving Objects One By One
                rolePersister.Delete(roleTrans.role, con, trans);
                if (roleTrans.role.IsError)
                {
                    roleTrans.IsError = true;
                    roleTrans.ErrorMessage = roleTrans.role.ErrorMessage;
                    roleTrans.ErrorMessageFor = roleTrans.role.ErrorMessageFor;
                    trans.Rollback();
                    con.Close();
                    return roleTrans;
                }

                trans.Commit();
                con.Close();
                return roleTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public static RoleTrans GetRoleTrans(Guid Id)
        {
            RoleTrans roleTrans = RoleTransPersister.Get();
            roleTrans.role = RolePersister.GetRole(Id);
            roleTrans.menuList = MenuList.GetParentListByRoleId(Id);
            return roleTrans;
        }

        public static RoleTrans Get()
        {
            RoleTrans roleTrans = new RoleTrans();
            roleTrans.role = RolePersister.Get();
            roleTrans.menuList = MenuList.GetParentList();
            return roleTrans;
        }

        public static RoleTransPersister GetPersister()
        {
            RoleTransPersister RoleTransPersister = new RoleTransPersister();
            return RoleTransPersister;
        }
    }
}
