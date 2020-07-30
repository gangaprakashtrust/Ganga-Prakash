using GangaPrakashAPI.Configuration.IDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.Dal
{
    public class IdentityTypeDal : IIdentityTypeDal
    {

        public List<IdentityTypeDto> Fetch()
        {
            List<IdentityTypeDto> result = new List<IdentityTypeDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select IT.Id,IT.Type from IdentityType IT Where IT.IsActive=1 Order By IT.Type ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public IdentityTypeDto IsIdentityTypeAlreadyPresent(IdentityTypeDto identityTypeDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select IT.Id,IT.Type from IdentityType IT Where Upper(Trim(IT.Type))=@name and IT.Id<>@id And IT.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", identityTypeDto.Id);
            cmd.Parameters.AddWithValue("@name", identityTypeDto.Type.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                identityTypeDto.ErrorCount = 1;
                identityTypeDto.ErrorMessage = "IdentityType already present";
            }
            con.Close();
            return identityTypeDto;
        }

        public IdentityTypeDto FetchById(Guid Id)
        {
            IdentityTypeDto result = new IdentityTypeDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select IT.Id,IT.Type from IdentityType IT Where IT.Id=@id and IT.IsActive=1", con);
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

        public IdentityTypeDto Insert(IdentityTypeDto identityTypeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into IdentityType(Type,IsActive) Output Inserted.Id Values(@name,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@name", identityTypeDto.Type);
            cmd.Parameters.AddWithValue("@isactive", identityTypeDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            identityTypeDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return identityTypeDto;
        }

        public IdentityTypeDto Update(IdentityTypeDto identityTypeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update IdentityType set Type=@name,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", identityTypeDto.Id);
            cmd.Parameters.AddWithValue("@name", identityTypeDto.Type);
            cmd.Parameters.AddWithValue("@isactive", identityTypeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return identityTypeDto;
        }

        public IdentityTypeDto Delete(IdentityTypeDto identityTypeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update IdentityType set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", identityTypeDto.Id);
            cmd.Parameters.AddWithValue("@isactive", identityTypeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return identityTypeDto;
        }

        public IdentityTypeDto GetDto(SqlDataReader sdr)
        {
            return new IdentityTypeDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Type = sdr.GetString(sdr.GetOrdinal("Type"))
            };
        }
    }
}
