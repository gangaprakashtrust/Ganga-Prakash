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
    public class UserRoleDal : IUserRoleDal
    {

        public List<UserRoleDto> Fetch()
        {
            List<UserRoleDto> result = new List<UserRoleDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select UR.Id,UR.ApplicationUserId,UR.RoleId from UserRole UR Where UR.IsActive=1 ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public List<UserRoleDto> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            List<UserRoleDto> result = new List<UserRoleDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select UR.Id,UR.ApplicationUserId,UR.RoleId from UserRole UR Where UR.ApplicationUserId=@applicationuserid And UR.IsActive=1 ", con);
            cmd.Parameters.AddWithValue("@applicationuserid", ApplicationUserId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public UserRoleDto FetchById(Guid Id)
        {
            UserRoleDto result = new UserRoleDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select UR.Id,UR.ApplicationUserId,UR.RoleId from UserRole UR Where UR.Id=@id and UR.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result = GetDto(dr);
            }
            con.Close();
            return result;
        }

        public UserRoleDto Insert(UserRoleDto userRoleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into UserRole(ApplicationUserId,RoleId,IsActive) Output Inserted.Id Values(@applicationuserid,@roleid,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@applicationuserid", userRoleDto.ApplicationUserId);
            cmd.Parameters.AddWithValue("@roleid", userRoleDto.RoleId);
            cmd.Parameters.AddWithValue("@isactive", userRoleDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            userRoleDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return userRoleDto;
        }

        public UserRoleDto Update(UserRoleDto userRoleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update UserRole set ApplicationUserId=@applicationuserid,RoleId=@roleid,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", userRoleDto.Id);
            cmd.Parameters.AddWithValue("@applicationuserid", userRoleDto.ApplicationUserId);
            cmd.Parameters.AddWithValue("@roleid", userRoleDto.RoleId);
            cmd.Parameters.AddWithValue("@isactive", userRoleDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return userRoleDto;
        }

        public void Delete(ApplicationUserDto applicationUserDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update UserRole set IsActive=@isactive Where ApplicationUserId=@applicationuserid ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", applicationUserDto.Id);
            cmd.Parameters.AddWithValue("@isactive", applicationUserDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
        }

        public UserRoleDto Delete(UserRoleDto userRoleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update UserRole set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", userRoleDto.Id);
            cmd.Parameters.AddWithValue("@isactive", userRoleDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return userRoleDto;
        }

        public UserRoleDto GetDto(SqlDataReader sdr)
        {
            return new UserRoleDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                ApplicationUserId = sdr.GetGuid(sdr.GetOrdinal("ApplicationUserId")),
                RoleId = sdr.GetGuid(sdr.GetOrdinal("RoleId")),
            };
        }
    }
}
