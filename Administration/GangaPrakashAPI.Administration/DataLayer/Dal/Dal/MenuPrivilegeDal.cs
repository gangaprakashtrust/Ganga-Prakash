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
    public class MenuPrivilegeDal : IMenuPrivilegeDal
    {

        public List<MenuPrivilegeDto> FetchByMenuId(Guid MenuId)
        {
            List<MenuPrivilegeDto> result = new List<MenuPrivilegeDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select MP.Id,MP.MenuId,MP.PrivilegeId from MenuPrivilege MP Where MP.IsActive=1 And MP.MenuId=@menuid", con);
            cmd.Parameters.AddWithValue("@menuid", MenuId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public MenuPrivilegeDto Insert(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into MenuPrivilege(MenuId,PrivilegeId,IsActive) Output Inserted.Id Values(@menuid,@privilegeid,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@menuid", menuPrivilegeDto.MenuId);
            cmd.Parameters.AddWithValue("@privilegeid", menuPrivilegeDto.PrivilegeId);
            cmd.Parameters.AddWithValue("@isactive", menuPrivilegeDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            menuPrivilegeDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return menuPrivilegeDto;
        }

        public MenuPrivilegeDto Update(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update MenuPrivilege set MenuId=@menuid,PrivilegeId=@privilegeid,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", menuPrivilegeDto.Id);
            cmd.Parameters.AddWithValue("@menuid", menuPrivilegeDto.MenuId);
            cmd.Parameters.AddWithValue("@privilegeid", menuPrivilegeDto.PrivilegeId);
            cmd.Parameters.AddWithValue("@isactive", menuPrivilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return menuPrivilegeDto;
        }

        public MenuPrivilegeDto Delete(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update MenuPrivilege set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", menuPrivilegeDto.Id);
            cmd.Parameters.AddWithValue("@isactive", menuPrivilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return menuPrivilegeDto;
        }

        public MenuPrivilegeDto DeletePrivilegeByMenu(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update MenuPrivilege set IsActive=@isactive Where MenuId=@menuid ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@menuid", menuPrivilegeDto.MenuId);
            cmd.Parameters.AddWithValue("@isactive", menuPrivilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return menuPrivilegeDto;
        }

        public MenuPrivilegeDto GetDto(SqlDataReader sdr)
        {
            return new MenuPrivilegeDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                MenuId = sdr.GetGuid(sdr.GetOrdinal("MenuId")),
                PrivilegeId = sdr.GetGuid(sdr.GetOrdinal("PrivilegeId")),
            };
        }
    }
}
