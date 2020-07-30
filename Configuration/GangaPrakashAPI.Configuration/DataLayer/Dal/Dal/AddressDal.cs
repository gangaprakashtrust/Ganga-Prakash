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
    public class AddressDal : IAddressDal
    {
        public AddressDto FetchById(Guid Id)
        {
            AddressDto result = new AddressDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select A.Id,A.CountryId,A.StateId,A.CityId,A.AddressLine,A.Area,A.Pincode from Address A Where A.Id=@id and A.IsActive=1", con);
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

        public AddressDto Insert(AddressDto addressDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into Address(CountryId,StateId,CityId,AddressLine,Area,Pincode,IsActive) Output Inserted.Id Values(@countryid,@stateid,@cityid,@addressline,@area,@pincode,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@countryid", addressDto.CountryId);
            cmd.Parameters.AddWithValue("@stateid", addressDto.StateId);
            cmd.Parameters.AddWithValue("@cityid", addressDto.CityId);
            cmd.Parameters.AddWithValue("@addressline", addressDto.AddressLine);
            cmd.Parameters.AddWithValue("@area", addressDto.Area);
            cmd.Parameters.AddWithValue("@pincode", addressDto.Pincode);
            cmd.Parameters.AddWithValue("@isactive", addressDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            addressDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return addressDto;
        }

        public AddressDto Update(AddressDto addressDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Address set CountryId=@countryid,StateId=@stateid,CityId=@cityid,AddressLine=@addressline,Area=@area,Pincode=@pincode,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", addressDto.Id);
            cmd.Parameters.AddWithValue("@stateid", addressDto.StateId);
            cmd.Parameters.AddWithValue("@cityid", addressDto.CityId);
            cmd.Parameters.AddWithValue("@addressline", addressDto.AddressLine);
            cmd.Parameters.AddWithValue("@area", addressDto.Area);
            cmd.Parameters.AddWithValue("@pincode", addressDto.Pincode);
            cmd.Parameters.AddWithValue("@isactive", addressDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return addressDto;
        }

        public AddressDto Delete(AddressDto addressDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Address set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", addressDto.Id);
            cmd.Parameters.AddWithValue("@isactive", addressDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return addressDto;
        }

        public AddressDto GetDto(SqlDataReader sdr)
        {
            return new AddressDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                CountryId = sdr.GetGuid(sdr.GetOrdinal("CountryId")),
                StateId = sdr.GetGuid(sdr.GetOrdinal("StateId")),
                CityId = sdr.GetGuid(sdr.GetOrdinal("CityId")),
                AddressLine = sdr.GetString(sdr.GetOrdinal("AddressLine")),
                Area = sdr.GetString(sdr.GetOrdinal("Area")),
                Pincode = sdr.GetString(sdr.GetOrdinal("Pincode")),
            };
        }
    }
}
