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
    public class CityDal : ICityDal
    {

        public List<CityDto> Fetch()
        {
            List<CityDto> result = new List<CityDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select C.Id,C.CountryId,C.StateId,C.Name,CO.Name as Country,S.Name as State from City C Inner Join State S On S.Id=C.StateId And C.IsActive=1 And S.IsActive=1  Inner Join Country CO On CO.Id=S.CountryId And CO.IsActive=1 And S.IsActive=1 Order By C.Name ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public CityDto IsCityAlreadyPresent(CityDto cityDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select C.Id,C.Name from City C Where Upper(Trim(C.Name))=@name and C.CountryId=@countryid And C.StateId=@stateid and C.Id<>@id And C.IsActive=1 ", con);
            cmd.Parameters.AddWithValue("@id", cityDto.Id);
            cmd.Parameters.AddWithValue("@countryid", cityDto.CountryId);
            cmd.Parameters.AddWithValue("@stateid", cityDto.StateId);
            cmd.Parameters.AddWithValue("@name", cityDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                cityDto.ErrorCount = 1;
                cityDto.ErrorMessage = "City already present";
            }
            con.Close();
            return cityDto;
        }

        public CityDto FetchById(Guid Id)
        {
            CityDto result = new CityDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select C.Id,C.CountryId,C.StateId,C.Name,CO.Name as Country,S.Name as State from City C Inner Join State S On S.Id=C.StateId And C.IsActive=1 And S.IsActive=1 And C.Id=@id Inner Join Country CO On CO.Id=S.CountryId And CO.IsActive=1 And S.IsActive=1 Order By C.Name ", con);
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

        public CityDto Insert(CityDto cityDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into City(CountryId,StateId,Name,IsActive) Output Inserted.Id Values(@countryid,@stateid,@name,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@countryid", cityDto.CountryId);
            cmd.Parameters.AddWithValue("@stateid", cityDto.StateId);
            cmd.Parameters.AddWithValue("@name", cityDto.Name);
            cmd.Parameters.AddWithValue("@isactive", cityDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            cityDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return cityDto;
        }

        public CityDto Update(CityDto cityDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update City set CountryId=@countryid,StateId=@stateid,Name=@name,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", cityDto.Id);
            cmd.Parameters.AddWithValue("@countryid", cityDto.CountryId);
            cmd.Parameters.AddWithValue("@stateid", cityDto.StateId);
            cmd.Parameters.AddWithValue("@name", cityDto.Name);
            cmd.Parameters.AddWithValue("@isactive", cityDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return cityDto;
        }

        public CityDto Delete(CityDto cityDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update City set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", cityDto.Id);
            cmd.Parameters.AddWithValue("@isactive", cityDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return cityDto;
        }

        public CityDto GetDto(SqlDataReader sdr)
        {
            return new CityDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                CountryId = sdr.GetGuid(sdr.GetOrdinal("CountryId")),
                StateId = sdr.GetGuid(sdr.GetOrdinal("StateId")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                Country = sdr.GetString(sdr.GetOrdinal("Country")),
                State = sdr.GetString(sdr.GetOrdinal("State"))
            };
        }
    }
}
