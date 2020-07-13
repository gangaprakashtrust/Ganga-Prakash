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
    public class RoleDal : IRoleDal
    {

        public List<RoleDto> Fetch()
        {
            List<RoleDto> result = new List<RoleDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select R.Id,R.Name from Role R Where R.IsActive=1 Order By R.Name  ASC", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public List<RoleDto> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            List<RoleDto> result = new List<RoleDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select R.Id,R.Name,case When(UR.Id is null) then 0 else 1 End as IsChecked 
                                               from Role R
                                               Left Outer join UserRole UR On UR.RoleId=R.Id 
                                               And UR.ApplicationUserId=@applicationuserid And R.IsActive=1 And UR.IsActive=1
                                               Group By R.Id,R.Name,UR.Id", con);
            cmd.Parameters.AddWithValue("@applicationuserid", ApplicationUserId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetUserRoleDto(dr));
            }
            con.Close();
            return result;
        }

        public RoleDto IsRoleAlreadyPresent(RoleDto roleDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select R.Id,R.Name from Role R Where Upper(Trim(R.Name))=@name and R.Id<>@id and R.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", roleDto.Id);
            cmd.Parameters.AddWithValue("@name", roleDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                roleDto.ErrorCount = 1;
                roleDto.ErrorMessage = "Role already present";
            }
            con.Close();
            return roleDto;
        }


        public RoleDto FetchById(Guid Id)
        {
            RoleDto result = new RoleDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select R.Id,R.Name from Role R Where R.Id=@id and R.IsActive=1", con);
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

        public RoleDto Insert(RoleDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into Role(Name,IsActive) Output Inserted.Id Values(@name,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@name", roleDto.Name);
            cmd.Parameters.AddWithValue("@isactive", roleDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            roleDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return roleDto;
        }

        public RoleDto Update(RoleDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Role set Name=@name,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", roleDto.Id);
            cmd.Parameters.AddWithValue("@name", roleDto.Name);
            cmd.Parameters.AddWithValue("@isactive", roleDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleDto;
        }

        public RoleDto Delete(RoleDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Role set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", roleDto.Id);
            cmd.Parameters.AddWithValue("@isactive", roleDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return roleDto;
        }

        public RoleDto GetDto(SqlDataReader sdr)
        {
            return new RoleDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
            };
        }

        public RoleDto GetUserRoleDto(SqlDataReader sdr)
        {
            return new RoleDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                IsChecked = ((sdr.GetInt32(sdr.GetOrdinal("IsChecked"))) == 1) ? true : false
            };
        }
    }
}
