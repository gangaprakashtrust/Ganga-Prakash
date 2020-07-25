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
    public class StateDal : IStateDal
    {

        public List<StateDto> Fetch()
        {
            List<StateDto> result = new List<StateDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select S.Id,S.CountryId,S.Name,C.Name as Country from State S Inner Join Country C On C.Id=S.CountryId And S.IsActive=1 And C.IsActive=1 Order By S.Name ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public StateDto IsStateAlreadyPresent(StateDto stateDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select S.Id,S.Name from State S Where Upper(Trim(S.Name))=@name and S.CountryId=@countryid and S.Id<>@id And S.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", stateDto.Id);
            cmd.Parameters.AddWithValue("@countryid", stateDto.CountryId);
            cmd.Parameters.AddWithValue("@name", stateDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                stateDto.ErrorCount = 1;
                stateDto.ErrorMessage = "State already present";
            }
            con.Close();
            return stateDto;
        }

        public StateDto FetchById(Guid Id)
        {
            StateDto result = new StateDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select S.Id,S.CountryId,S.Name,C.Name as Country from State S Inner Join Country C On C.Id=S.CountryId And S.IsActive=1 And C.IsActive=1 And S.Id=@id ", con);
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

        public StateDto Insert(StateDto stateDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into State(CountryId,Name,IsActive) Output Inserted.Id Values(@countryid,@name,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@countryid", stateDto.CountryId);
            cmd.Parameters.AddWithValue("@name", stateDto.Name);
            cmd.Parameters.AddWithValue("@isactive", stateDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            stateDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return stateDto;
        }

        public StateDto Update(StateDto stateDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update State set CountryId=@countryid,Name=@name,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", stateDto.Id);
            cmd.Parameters.AddWithValue("@countryid", stateDto.CountryId);
            cmd.Parameters.AddWithValue("@name", stateDto.Name);
            cmd.Parameters.AddWithValue("@isactive", stateDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return stateDto;
        }

        public StateDto Delete(StateDto stateDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update State set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", stateDto.Id);
            cmd.Parameters.AddWithValue("@isactive", stateDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return stateDto;
        }

        public StateDto GetDto(SqlDataReader sdr)
        {
            return new StateDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                CountryId = sdr.GetGuid(sdr.GetOrdinal("CountryId")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                Country = sdr.GetString(sdr.GetOrdinal("Country"))
            };
        }
    }
}
