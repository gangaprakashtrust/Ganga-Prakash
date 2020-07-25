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
    public class CountryDal : ICountryDal
    {

        public List<CountryDto> Fetch()
        {
            List<CountryDto> result = new List<CountryDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select C.Id,C.Name from Country C Where C.IsActive=1 Order By C.Name ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public Boolean IsStateReferencePresent(Guid CountryId)
        {
            Boolean IsStateReferencePresent = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select S.Id from State S Where S.CountryId=@countryid and S.IsActive=1", con);
            cmd.Parameters.AddWithValue("@countryid", CountryId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                IsStateReferencePresent = true;
            }
            con.Close();
            return IsStateReferencePresent;
        }

        public CountryDto IsCountryAlreadyPresent(CountryDto countryDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select C.Id,C.Name from Country C Where Upper(Trim(C.Name))=@name and C.Id<>@id And C.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", countryDto.Id);
            cmd.Parameters.AddWithValue("@name", countryDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                countryDto.ErrorCount = 1;
                countryDto.ErrorMessage = "Country already present";
            }
            con.Close();
            return countryDto;
        }

        public CountryDto FetchById(Guid Id)
        {
            CountryDto result = new CountryDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select C.Id,C.Name from Country C Where C.Id=@id and C.IsActive=1", con);
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

        public CountryDto Insert(CountryDto countryDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into Country(Name,IsActive) Output Inserted.Id Values(@name,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@name", countryDto.Name);
            cmd.Parameters.AddWithValue("@isactive", countryDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            countryDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return countryDto;
        }

        public CountryDto Update(CountryDto countryDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Country set Name=@name,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", countryDto.Id);
            cmd.Parameters.AddWithValue("@name", countryDto.Name);
            cmd.Parameters.AddWithValue("@isactive", countryDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return countryDto;
        }

        public CountryDto Delete(CountryDto countryDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Country set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", countryDto.Id);
            cmd.Parameters.AddWithValue("@isactive", countryDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return countryDto;
        }

        public CountryDto GetDto(SqlDataReader sdr)
        {
            return new CountryDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name"))
            };
        }
    }
}
