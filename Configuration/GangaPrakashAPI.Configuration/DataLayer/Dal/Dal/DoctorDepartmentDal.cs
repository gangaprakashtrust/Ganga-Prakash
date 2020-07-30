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
    public class DoctorDepartmentDal : IDoctorDepartmentDal
    {

        public List<DoctorDepartmentDto> Fetch()
        {
            List<DoctorDepartmentDto> result = new List<DoctorDepartmentDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select DD.Id,DD.DoctorId,DD.DepartmentId from DoctorDepartment DD Where DD.IsActive=1 ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public DoctorDepartmentDto Insert(DoctorDepartmentDto doctorDepartmentDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into DoctorDepartment(DoctorId,DepartmentId,IsActive) Output Inserted.Id Values(@doctorid,@departmentid,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@doctorid", doctorDepartmentDto.DoctorId);
            cmd.Parameters.AddWithValue("@departmentid", doctorDepartmentDto.DepartmentId);
            cmd.Parameters.AddWithValue("@isactive", doctorDepartmentDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            doctorDepartmentDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return doctorDepartmentDto;
        }

        public DoctorDepartmentDto Update(DoctorDepartmentDto doctorDepartmentDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update DoctorDepartment set DoctorId=@doctorid,DepartmentId=@departmentid,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", doctorDepartmentDto.Id);
            cmd.Parameters.AddWithValue("@doctorid", doctorDepartmentDto.DoctorId);
            cmd.Parameters.AddWithValue("@departmentid", doctorDepartmentDto.DepartmentId);
            cmd.Parameters.AddWithValue("@isactive", doctorDepartmentDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return doctorDepartmentDto;
        }

        public DoctorDepartmentDto Delete(DoctorDepartmentDto doctorDepartmentDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update DoctorDepartment set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", doctorDepartmentDto.Id);
            cmd.Parameters.AddWithValue("@isactive", doctorDepartmentDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return doctorDepartmentDto;
        }

        public DoctorDepartmentDto GetDto(SqlDataReader sdr)
        {
            return new DoctorDepartmentDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                DoctorId = sdr.GetGuid(sdr.GetOrdinal("DoctorId")),
                DepartmentId = sdr.GetGuid(sdr.GetOrdinal("DepartmentId"))
            };
        }
    }
}
