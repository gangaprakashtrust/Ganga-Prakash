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
    public class ApplicationUserDal : IApplicationUserDal
    {

        public List<ApplicationUserDto> Fetch()
        {
            List<ApplicationUserDto> result = new List<ApplicationUserDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select AU.Id,AU.UserId,AU.UserName,AU.FirstName,AU.LastName,AU.Email,AU.ShortName,AU.MobileNo,AU.ImagePath,AU.IsDoctor from ApplicationUser AU Where AU.IsActive=1", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public String GetApplicationUserIdBySystemUserId(Guid SystemUserId)
        {
            List<ApplicationUserDto> result = new List<ApplicationUserDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select AU.Id from ApplicationUser AU Where AU.UserId=@userid And AU.IsActive=1", con);
            cmd.Parameters.AddWithValue("@userid", SystemUserId);
            con.Open();
            String ApplicationUserId = cmd.ExecuteScalar().ToString();
            con.Close();
            return ApplicationUserId;
        }

        public ApplicationUserDto IsApplicationUserAlreadyPresent(ApplicationUserDto applicationUserDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select AU.Id,AU.Email from ApplicationUser AU Where Upper(Trim(AU.Email))=@email and AU.Id<>@id And AU.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", applicationUserDto.Id);
            cmd.Parameters.AddWithValue("@email", applicationUserDto.Email.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                applicationUserDto.ErrorCount = 1;
                applicationUserDto.ErrorMessage = "Email already registered!";
            }
            con.Close();
            return applicationUserDto;
        }

        public ApplicationUserDto FetchById(Guid Id)
        {
            ApplicationUserDto result = new ApplicationUserDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select AU.Id,AU.UserId,AU.UserName,AU.FirstName,AU.LastName,AU.Email,AU.ShortName,AU.MobileNo,AU.ImagePath,AU.IsDoctor from ApplicationUser AU Where AU.Id=@id and AU.IsActive=1", con);
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

        public ApplicationUserDto Insert(ApplicationUserDto applicationUserDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into ApplicationUser(UserId,UserName,FirstName,LastName,Email,ShortName,MobileNo,ImagePath,IsDoctor,IsActive) Output Inserted.Id Values(@userid,@username,@firstname,@lastname,@email,@shortname,@mobileno,@imagepath,@isdoctor,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@userid", applicationUserDto.UserId);
            cmd.Parameters.AddWithValue("@username", applicationUserDto.UserName);
            cmd.Parameters.AddWithValue("@firstname", applicationUserDto.FirstName);
            cmd.Parameters.AddWithValue("@lastname", applicationUserDto.LastName);
            cmd.Parameters.AddWithValue("@email", applicationUserDto.Email);
            cmd.Parameters.AddWithValue("@shortname", applicationUserDto.ShortName);
            cmd.Parameters.AddWithValue("@mobileno", applicationUserDto.MobileNo);
            cmd.Parameters.AddWithValue("@imagepath", applicationUserDto.ImagePath ?? String.Empty);
            cmd.Parameters.AddWithValue("@isdoctor", applicationUserDto.IsDoctor);
            cmd.Parameters.AddWithValue("@isactive", applicationUserDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            applicationUserDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return applicationUserDto;
        }

        public ApplicationUserDto Update(ApplicationUserDto applicationUserDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update ApplicationUser set UserId=@userid,UserName=@username,FirstName=@firstname,LastName=@lastname,Email=@email,ShortName=@shortname,MobileNo=@mobileno,ImagePath=@imagepath,IsDoctor=@isdoctor,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", applicationUserDto.Id);
            cmd.Parameters.AddWithValue("@userid", applicationUserDto.UserId);
            cmd.Parameters.AddWithValue("@username", applicationUserDto.UserName);
            cmd.Parameters.AddWithValue("@firstname", applicationUserDto.FirstName);
            cmd.Parameters.AddWithValue("@lastname", applicationUserDto.LastName);
            cmd.Parameters.AddWithValue("@email", applicationUserDto.Email);
            cmd.Parameters.AddWithValue("@shortname", applicationUserDto.ShortName);
            cmd.Parameters.AddWithValue("@mobileno", applicationUserDto.MobileNo);
            cmd.Parameters.AddWithValue("@imagepath", applicationUserDto.ImagePath ?? String.Empty);
            cmd.Parameters.AddWithValue("@isdoctor", applicationUserDto.IsDoctor);
            cmd.Parameters.AddWithValue("@isactive", applicationUserDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return applicationUserDto;
        }

        public ApplicationUserDto Delete(ApplicationUserDto applicationUserDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update ApplicationUser set IsActive=@isactive Where Id=@id ", con);
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
            return applicationUserDto;
        }

        public ApplicationUserDto GetDto(SqlDataReader sdr)
        {
            return new ApplicationUserDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                UserId = sdr.GetGuid(sdr.GetOrdinal("UserId")),
                UserName = sdr.GetString(sdr.GetOrdinal("UserName")),
                FirstName = sdr.GetString(sdr.GetOrdinal("FirstName")),
                LastName = sdr.GetString(sdr.GetOrdinal("LastName")),
                Email = sdr.GetString(sdr.GetOrdinal("Email")),
                ShortName = sdr.GetString(sdr.GetOrdinal("ShortName")),
                MobileNo = sdr.GetString(sdr.GetOrdinal("MobileNo")),
                ImagePath = sdr.GetString(sdr.GetOrdinal("ImagePath")),
                IsDoctor = sdr.GetBoolean(sdr.GetOrdinal("IsDoctor"))
            };
        }
    }
}
