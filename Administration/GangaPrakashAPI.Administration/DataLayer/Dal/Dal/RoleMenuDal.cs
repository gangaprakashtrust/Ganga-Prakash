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
    public class RoleMenuDal : IRoleMenuDal
    {

        public List<RoleMenuDto> FetchByRoleId(Guid RoleId)
        {
            List<RoleMenuDto> result = new List<RoleMenuDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select MP.Id,MP.RoleId,MP.MenuId from RoleMenu MP Where MP.IsActive=1 And MP.RoleId=@roleid", con);
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

        public RoleMenuDto Insert(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into RoleMenu(RoleId,MenuId,IsActive) Output Inserted.Id Values(@roleid,@menuid,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@roleid", roleMenuDto.RoleId);
            cmd.Parameters.AddWithValue("@menuid", roleMenuDto.MenuId);
            cmd.Parameters.AddWithValue("@isactive", roleMenuDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            roleMenuDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuDto;
        }

        public RoleMenuDto Update(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update RoleMenu set RoleId=@roleid,MenuId=@menuid,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", roleMenuDto.Id);
            cmd.Parameters.AddWithValue("@roleid", roleMenuDto.RoleId);
            cmd.Parameters.AddWithValue("@menuid", roleMenuDto.MenuId);
            cmd.Parameters.AddWithValue("@isactive", roleMenuDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuDto;
        }

        public RoleMenuDto Delete(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update RoleMenu set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", roleMenuDto.Id);
            cmd.Parameters.AddWithValue("@isactive", roleMenuDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuDto;
        }

        public RoleMenuDto DeleteRoleMenuByRole(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update RoleMenu set IsActive=@isactive Where RoleId=@roleid ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@roleid", roleMenuDto.RoleId);
            cmd.Parameters.AddWithValue("@isactive", roleMenuDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleMenuDto;
        }

        public RoleMenuDto GetDto(SqlDataReader sdr)
        {
            return new RoleMenuDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                RoleId = sdr.GetGuid(sdr.GetOrdinal("RoleId")),
                MenuId = sdr.GetGuid(sdr.GetOrdinal("MenuId")),
            };
        }
    }
}
