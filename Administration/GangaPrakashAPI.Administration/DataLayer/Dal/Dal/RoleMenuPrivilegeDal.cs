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
    public class RoleMenuPrivilegeDal : IRoleMenuPrivilegeDal
    {

        public List<RoleMenuPrivilegeDto> FetchByRoleId(Guid RoleId)
        {
            List<RoleMenuPrivilegeDto> result = new List<RoleMenuPrivilegeDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select RMP.Id,RMP.RoleMenuId,RMP.PrivilegeId from RoleMenuPrivilege RMP Where RMP.IsActive=1 And RMP.RoleMenuId=@roleid", con);
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

        public RoleMenuPrivilegeDto Insert(RoleMenuPrivilegeDto roleMenuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
        {
            SqlConnection con;
            if (transcon != null)
            {
                con = transcon;
            }
            else
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(" Insert Into RoleMenuPrivilege(RoleMenuId,PrivilegeId,IsActive) Output Inserted.Id Values(@rolemenuid,@privilegeid,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@rolemenuid", roleMenuPrivilegeDto.RoleMenuId);
            cmd.Parameters.AddWithValue("@privilegeid", roleMenuPrivilegeDto.PrivilegeId);
            cmd.Parameters.AddWithValue("@isactive", roleMenuPrivilegeDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            roleMenuPrivilegeDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuPrivilegeDto;
        }

        public RoleMenuPrivilegeDto Update(RoleMenuPrivilegeDto roleMenuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
        {
            SqlConnection con;
            if (transcon != null)
            {
                con = transcon;
            }
            else
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(" Update RoleMenuPrivilege set RoleMenuId=@rolemenuid,PrivilegeId=@privilegeid,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", roleMenuPrivilegeDto.Id);
            cmd.Parameters.AddWithValue("@rolemenuid", roleMenuPrivilegeDto.RoleMenuId);
            cmd.Parameters.AddWithValue("@privilegeid", roleMenuPrivilegeDto.PrivilegeId);
            cmd.Parameters.AddWithValue("@isactive", roleMenuPrivilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuPrivilegeDto;
        }

        public RoleMenuPrivilegeDto Delete(RoleMenuPrivilegeDto roleMenuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
        {
            SqlConnection con;
            if (transcon != null)
            {
                con = transcon;
            }
            else
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(" Update RoleMenuPrivilege set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", roleMenuPrivilegeDto.Id);
            cmd.Parameters.AddWithValue("@isactive", roleMenuPrivilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuPrivilegeDto;
        }

        public RoleMenuPrivilegeDto GetDto(SqlDataReader sdr)
        {
            return new RoleMenuPrivilegeDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                RoleMenuId = sdr.GetGuid(sdr.GetOrdinal("RoleMenuId")),
                PrivilegeId = sdr.GetGuid(sdr.GetOrdinal("PrivilegeId")),
            };
        }
    }
}
