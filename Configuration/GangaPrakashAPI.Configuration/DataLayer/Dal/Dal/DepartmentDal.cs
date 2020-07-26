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
    public class DepartmentDal : IDepartmentDal
    {

        public List<DepartmentDto> Fetch()
        {
            List<DepartmentDto> result = new List<DepartmentDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select D.Id,D.Name from Department D Where D.IsActive=1 Order By D.Name ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public DepartmentDto IsDepartmentAlreadyPresent(DepartmentDto departmentDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select D.Id,D.Name from Department D Where Upper(Trim(D.Name))=@name and D.Id<>@id And D.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", departmentDto.Id);
            cmd.Parameters.AddWithValue("@name", departmentDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                departmentDto.ErrorCount = 1;
                departmentDto.ErrorMessage = "Department already present";
            }
            con.Close();
            return departmentDto;
        }

        public DepartmentDto FetchById(Guid Id)
        {
            DepartmentDto result = new DepartmentDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select D.Id,D.Name from Department D Where D.Id=@id and D.IsActive=1", con);
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

        public DepartmentDto Insert(DepartmentDto departmentDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into Department(Name,IsActive) Output Inserted.Id Values(@name,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@name", departmentDto.Name);
            cmd.Parameters.AddWithValue("@isactive", departmentDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            departmentDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return departmentDto;
        }

        public DepartmentDto Update(DepartmentDto departmentDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Department set Name=@name,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", departmentDto.Id);
            cmd.Parameters.AddWithValue("@name", departmentDto.Name);
            cmd.Parameters.AddWithValue("@isactive", departmentDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return departmentDto;
        }

        public DepartmentDto Delete(DepartmentDto departmentDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Department set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", departmentDto.Id);
            cmd.Parameters.AddWithValue("@isactive", departmentDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return departmentDto;
        }

        public DepartmentDto GetDto(SqlDataReader sdr)
        {
            return new DepartmentDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name"))
            };
        }
    }
}
