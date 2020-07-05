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
    public class ApplicationUserTransPersister
    {
        public ApplicationUserTrans Insert(ApplicationUserTrans applicationUserTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                ApplicationUserPersister applicationUserPersister = ApplicationUserPersister.GetPersister();

                //Now Saving Objects One By One
                applicationUserTrans.applicationUser = applicationUserPersister.Insert(applicationUserTrans.applicationUser, con, trans);
                if (applicationUserTrans.applicationUser.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return applicationUserTrans;
                }

                foreach (var item in applicationUserTrans.roleList.Where(a => a.IsChecked))
                {
                    UserRolePersister userRolePersister = UserRolePersister.GetPersister();
                    UserRole userRole = UserRolePersister.Get();
                    userRole.ApplicationUserId = applicationUserTrans.applicationUser.Id;
                    userRole.RoleId = item.Id;
                    userRolePersister.Insert(userRole, con, trans);
                }
                trans.Commit();
                con.Close();
                return applicationUserTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        public ApplicationUserTrans Update(ApplicationUserTrans applicationUserTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                ApplicationUserPersister applicationUserPersister = ApplicationUserPersister.GetPersister();
                List<UserRole> userRoleList = UserRoleList.GetListByApplicationUserId(applicationUserTrans.applicationUser.Id);

                //Now Saving Objects One By One
                applicationUserTrans.applicationUser = applicationUserPersister.Update(applicationUserTrans.applicationUser, con, trans);
                if (applicationUserTrans.applicationUser.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return applicationUserTrans;
                }

                //Adding and updating new records
                List<Guid> CheckedPrivileged = new List<Guid>();
                foreach (var item in applicationUserTrans.roleList.Where(a => a.IsChecked))
                {
                    Boolean IsPrivileAlreadyPresent = (userRoleList.Where(a => a.RoleId == item.Id && a.ApplicationUserId == applicationUserTrans.applicationUser.Id).ToList().Count > 0) ? true : false;
                    if (!IsPrivileAlreadyPresent)
                    {
                        CheckedPrivileged.Add(item.Id);
                    }

                }
                foreach (var item in CheckedPrivileged)
                {
                    UserRolePersister userRolePersister = UserRolePersister.GetPersister();
                    UserRole userRole = UserRolePersister.Get();
                    userRole.ApplicationUserId = applicationUserTrans.applicationUser.Id;
                    userRole.RoleId = item;
                    userRolePersister.Insert(userRole, con, trans);
                }

                //Deleting deleted records
                foreach (var item in applicationUserTrans.roleList.Where(a => a.IsChecked == false))
                {
                    if (userRoleList.Where(a => a.RoleId == item.Id).ToList().Count > 0)
                    {
                        UserRolePersister userRolePersister = UserRolePersister.GetPersister();
                        userRolePersister.Delete(userRoleList.Where(a => a.RoleId.Equals(item.Id)).FirstOrDefault(), con, trans);
                    }
                }
                trans.Commit();
                con.Close();
                return applicationUserTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public ApplicationUserTrans Delete(ApplicationUserTrans applicationUserTrans)
        {
            //Sql Connection Object And Transaction Object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                //Declaring Required Persister Objects.
                ApplicationUserPersister applicationUserPersister = ApplicationUserPersister.GetPersister();
                UserRolePersister userRolePersister = UserRolePersister.GetPersister();

                //Now Saving Objects One By One
                applicationUserPersister.Delete(applicationUserTrans.applicationUser, con, trans);
                if (applicationUserTrans.applicationUser.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return applicationUserTrans;
                }
                userRolePersister.Delete(applicationUserTrans.applicationUser, con, trans);
                if (applicationUserTrans.applicationUser.IsError)
                {
                    trans.Rollback();
                    con.Close();
                    return applicationUserTrans;
                }
                trans.Commit();
                con.Close();
                return applicationUserTrans;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }


        }

        public static ApplicationUserTrans GetApplicationUserTrans(Guid Id)
        {
            ApplicationUserTrans applicationUserTrans = ApplicationUserTransPersister.Get();
            applicationUserTrans.applicationUser = ApplicationUserPersister.GetApplicationUser(Id);
            applicationUserTrans.roleList = RoleList.GetListByApplicationUserId(Id);
            return applicationUserTrans;
        }

        public static ApplicationUserTrans Get()
        {
            ApplicationUserTrans applicationUserTrans = new ApplicationUserTrans();
            applicationUserTrans.applicationUser = ApplicationUserPersister.Get();
            applicationUserTrans.roleList = RoleList.GetList();
            return applicationUserTrans;
        }

        public static ApplicationUserTransPersister GetPersister()
        {
            ApplicationUserTransPersister ApplicationUserTransPersister = new ApplicationUserTransPersister();
            return ApplicationUserTransPersister;
        }
    }
}
