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
            List<RoleDto> Result = new List<RoleDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select R.Id,R.Name from Role R Where R.IsActive=1 Order By R.Name  ASC", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Result.Add(GetDto(dr));
            }
            con.Close();
            return Result;
        }

        public RoleDto IsRoleAlreadyPresent(RoleDto RoleDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select R.Id,R.Name from Role R Where Upper(Trim(R.Name))=@name and R.Id<>@id and R.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", RoleDto.Id);
            cmd.Parameters.AddWithValue("@name", RoleDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                RoleDto.ErrorCount = 1;
                RoleDto.ErrorMessage = "Role already present";
            }
            con.Close();
            return RoleDto;
        }


        public RoleDto FetchById(Guid Id)
        {
            RoleDto Result = new RoleDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select R.Id,R.Name from Role R Where R.Id=@id and R.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Result = GetDto(dr);
            }
            con.Close();
            return Result;
        }

        public RoleDto Insert(RoleDto RoleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            cmd.Parameters.AddWithValue("@name", RoleDto.Name);
            cmd.Parameters.AddWithValue("@isactive", RoleDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            RoleDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return RoleDto;
        }

        public RoleDto Update(RoleDto RoleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            cmd.Parameters.AddWithValue("@id", RoleDto.Id);
            cmd.Parameters.AddWithValue("@name", RoleDto.Name);
            cmd.Parameters.AddWithValue("@isactive", RoleDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return RoleDto;
        }

        public RoleDto Delete(RoleDto RoleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            cmd.Parameters.AddWithValue("@id", RoleDto.Id);
            cmd.Parameters.AddWithValue("@isactive", RoleDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return RoleDto;
        }

        public RoleDto GetDto(SqlDataReader sdr)
        {
            return new RoleDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
            };
        }
    }
}
