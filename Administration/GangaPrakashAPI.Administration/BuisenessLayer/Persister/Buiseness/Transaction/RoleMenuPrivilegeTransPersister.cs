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
    public class RoleMenuPrivilegeTransPersister
    {
        public RoleMenuPrivilegeTrans Update(RoleMenuPrivilegeTrans roleMenuPrivilegeTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                List<RoleMenuPrivilege> roleMenuPrivilegeList = RoleMenuPrivilegeList.GetListByRoleId(roleMenuPrivilegeTrans.RoleId);
                List<RoleMenuPrivilege> CheckedPrivilegeId = new List<RoleMenuPrivilege>();
                foreach (var item in roleMenuPrivilegeTrans.PrivilegeList.Where(a => a.IsChecked))
                {
                    Boolean IsPrivileAlreadyPresent = (roleMenuPrivilegeList.Where(a => a.PrivilegeId == item.PrivilegeId && a.RoleMenuId == item.RoleMenuId).ToList().Count > 0) ? true : false;
                    if (!IsPrivileAlreadyPresent)
                    {
                        CheckedPrivilegeId.Add(new RoleMenuPrivilege
                        {
                            PrivilegeId=item.PrivilegeId,
                            RoleMenuId=item.RoleMenuId
                        });
                    }

                }
                foreach (var item in CheckedPrivilegeId)
                {
                    RoleMenuPrivilegePersister roleMenuPrivilegePersister = RoleMenuPrivilegePersister.GetPersister();
                    RoleMenuPrivilege roleMenuPrivilege = RoleMenuPrivilegePersister.Get();
                    roleMenuPrivilege.RoleMenuId = item.RoleMenuId;
                    roleMenuPrivilege.PrivilegeId = item.PrivilegeId;
                    roleMenuPrivilegePersister.Insert(roleMenuPrivilege, con, trans);
                    if (roleMenuPrivilege.IsError)
                    {
                        roleMenuPrivilegeTrans.IsError = true;
                        roleMenuPrivilegeTrans.ErrorMessage = roleMenuPrivilege.ErrorMessage;
                        roleMenuPrivilegeTrans.ErrorMessageFor = roleMenuPrivilege.ErrorMessageFor;
                        trans.Rollback();
                        con.Close();
                        return roleMenuPrivilegeTrans;
                    }
                }

                //Deleting deleted records
                foreach (var item in roleMenuPrivilegeTrans.PrivilegeList.Where(a => a.IsChecked == false))
                {
                    if (roleMenuPrivilegeList.Where(a => a.RoleMenuId == item.RoleMenuId && a.PrivilegeId==item.PrivilegeId).ToList().Count > 0)
                    {
                        RoleMenuPrivilegePersister roleMenuPrivilegePersister = RoleMenuPrivilegePersister.GetPersister();
                        RoleMenuPrivilege roleMenuPrivilege = roleMenuPrivilegeList.Where(a => a.RoleMenuId == item.RoleMenuId && a.PrivilegeId == item.PrivilegeId).FirstOrDefault();
                        roleMenuPrivilegePersister.Delete(roleMenuPrivilege, con, trans);
                        if (roleMenuPrivilege.IsError)
                        {
                            roleMenuPrivilegeTrans.IsError = true;
                            roleMenuPrivilegeTrans.ErrorMessage = roleMenuPrivilege.ErrorMessage;
                            roleMenuPrivilegeTrans.ErrorMessageFor = roleMenuPrivilege.ErrorMessageFor;
                            trans.Rollback();
                            con.Close();
                            return roleMenuPrivilegeTrans;
                        }
                    }
                }
                trans.Commit();
                con.Close();
                return roleMenuPrivilegeTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public static RoleMenuPrivilegeTrans GetRoleMenuPrivilegeTrans(Guid RoleId)
        {
            RoleMenuPrivilegeTrans roleMenuPrivilegeTrans = RoleMenuPrivilegeTransPersister.Get();
            roleMenuPrivilegeTrans.PrivilegeList = RoleMenuPrivilegeHelperList.GetListByRoleId(RoleId);
            return roleMenuPrivilegeTrans;
        }

        public static RoleMenuPrivilegeTrans Get()
        {
            RoleMenuPrivilegeTrans roleMenuPrivilegeTrans = new RoleMenuPrivilegeTrans();
            roleMenuPrivilegeTrans.PrivilegeList = new List<RoleMenuPrivilegeHelper>();
            return roleMenuPrivilegeTrans;
        }

        public static RoleMenuPrivilegeTransPersister GetPersister()
        {
            RoleMenuPrivilegeTransPersister RoleMenuPrivilegeTransPersister = new RoleMenuPrivilegeTransPersister();
            return RoleMenuPrivilegeTransPersister;
        }
    }
}
