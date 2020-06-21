using GangaPrakashAPI.Administration.IDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.Dal
{
    public class RoleMenuPrivilegeHelperDal : IRoleMenuPrivilegeHelperDal
    {

        public List<RoleMenuPrivilegeHelperDto> FetchByRoleId(Guid RoleId)
        {
            List<RoleMenuPrivilegeHelperDto> result = new List<RoleMenuPrivilegeHelperDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select P.Id as PrivilegeId,case When(RMP.Id is null) then 0 else 1 End as IsChecked,M.Name as Menu,MO.Name as Module,P.Name,MO.Id as ModuleId,M.Id as MenuId,RM.Id as RoleMenuId,M.SequenceNo as MenuSequenceNo,P.SequenceNo as PrivilegeSequenceNo from Privilege P
                                               Inner Join MenuPrivilege MP On MP.PrivilegeId=P.Id And P.IsActive=1 And MP.IsActive=1
                                               Inner Join Menu M On MP.MenuId=M.Id And M.IsACtive=1 And M.ParentId <> '00000000-0000-0000-0000-000000000000' And M.IsACtive=1 And MP.IsActive=1
                                               Inner Join RoleMenu RM On RM.MenuId=M.Id And RM.IsActive=1 And M.IsActive=1 And RM.RoleId=@roleid
                                               Inner Join Module MO On MO.Id=M.ModuleId And MO.IsActive=1 And M.IsActive=1
                                               Left Join RoleMenuPrivilege RMP on RMP.PrivilegeId=P.Id And RMP.RoleMenuId=RM.Id And RMP.IsActive=1 And P.IsActive=1 And RM.IsActive=1
                                               Order By MO.Id", con);
            cmd.Parameters.AddWithValue("@roleid", RoleId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public RoleMenuPrivilegeHelperDto GetDto(SqlDataReader sdr)
        {
            return new RoleMenuPrivilegeHelperDto
            {
                PrivilegeId = sdr.GetGuid(sdr.GetOrdinal("PrivilegeId")),
                IsChecked = ((sdr.GetInt32(sdr.GetOrdinal("IsChecked"))) == 1) ? true : false,
                Menu = sdr.GetString(sdr.GetOrdinal("Menu")),
                Module = sdr.GetString(sdr.GetOrdinal("Module")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                ModuleId = sdr.GetGuid(sdr.GetOrdinal("ModuleId")),
                MenuId = sdr.GetGuid(sdr.GetOrdinal("MenuId")),
                RoleMenuId = sdr.GetGuid(sdr.GetOrdinal("RoleMenuId")),
                MenuSequenceNo = sdr.GetInt32(sdr.GetOrdinal("MenuSequenceNo")),
                PrivilegeSequenceNo = sdr.GetInt32(sdr.GetOrdinal("PrivilegeSequenceNo")),
            };
        }
    }
}
