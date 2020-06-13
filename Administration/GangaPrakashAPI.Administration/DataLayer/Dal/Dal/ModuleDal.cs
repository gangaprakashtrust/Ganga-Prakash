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
	public class ModuleDal : IModuleDal
	{

		public List<ModuleDto> Fetch()
		{
			List<ModuleDto> result = new List<ModuleDto>();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name,M.SequenceNo from Module M Where M.IsActive=1 Order By M.SequenceNo ASC", con);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				result.Add(GetDto(dr));
			}
			con.Close();
			return result;
		}

		public ModuleDto IsModuleAlreadyPresent(ModuleDto moduleDto)
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name from Module M Where Upper(Trim(M.Name))=@name and M.Id<>@id And M.IsActive=1", con);
			cmd.Parameters.AddWithValue("@id", moduleDto.Id);
			cmd.Parameters.AddWithValue("@name", moduleDto.Name.Trim().ToUpper());
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				moduleDto.ErrorCount = 1;
				moduleDto.ErrorMessage = "Module already present";
			}
			con.Close();
			return moduleDto;
		}

		public ModuleDto IsSequenceNoAlreadyPresent(ModuleDto moduleDto)
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name from Module M Where M.SequenceNo=@sequenceno and M.Id<>@id and M.IsActive=1", con);
			cmd.Parameters.AddWithValue("@id", moduleDto.Id);
			cmd.Parameters.AddWithValue("@sequenceno", moduleDto.SequenceNo);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				moduleDto.ErrorCount = 1;
				moduleDto.ErrorMessage = "Sequence No. already present";
			}
			con.Close();
			return moduleDto;
		}

		public Boolean IsMenuReferencePresent(Guid ModuleId)
		{
			Boolean IsMenuReferencePresent = false;
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id from Menu M Where M.ModuleId=@moduleid and M.IsActive=1", con);
			cmd.Parameters.AddWithValue("@moduleid", ModuleId);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				IsMenuReferencePresent = true;
			}
			con.Close();
			return IsMenuReferencePresent;
		}

		public ModuleDto FetchById(Guid Id)
		{
			ModuleDto result = new ModuleDto();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name,M.SequenceNo from Module M Where M.Id=@id and M.IsActive=1", con);
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

		public ModuleDto Insert(ModuleDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			SqlCommand cmd = new SqlCommand(" Insert Into Module(Name,SequenceNo,IsActive) Output Inserted.Id Values(@name,@sequenceno,@isactive) ", con);
			if (transcon != null)
			{
				cmd.Transaction = trans;
			}
			cmd.Parameters.AddWithValue("@name", moduleDto.Name);
			cmd.Parameters.AddWithValue("@sequenceno", moduleDto.SequenceNo);
			cmd.Parameters.AddWithValue("@isactive", moduleDto.IsActive);

			Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
			moduleDto.Id = InsertedId;
			if (transcon == null)
			{
				con.Close();
			}
			return moduleDto;
		}

		public ModuleDto Update(ModuleDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			SqlCommand cmd = new SqlCommand(" Update Module set Name=@name,SequenceNo=@sequenceno,IsActive=@isactive Where Id=@id ", con);
			if (transcon != null)
			{
				cmd.Transaction = trans;
			}
			cmd.Parameters.AddWithValue("@id", moduleDto.Id);
			cmd.Parameters.AddWithValue("@name", moduleDto.Name);
			cmd.Parameters.AddWithValue("@sequenceno", moduleDto.SequenceNo);
			cmd.Parameters.AddWithValue("@isactive", moduleDto.IsActive);
			Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
			if (transcon == null)
			{
				con.Close();
			}
			return moduleDto;
		}

		public ModuleDto Delete(ModuleDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			SqlCommand cmd = new SqlCommand(" Update Module set IsActive=@isactive Where Id=@id ", con);
			if (transcon != null)
			{
				cmd.Transaction = trans;
			}
			cmd.Parameters.AddWithValue("@id", moduleDto.Id);
			cmd.Parameters.AddWithValue("@isactive", moduleDto.IsActive);
			Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
			if (transcon == null)
			{
				con.Close();
			}
			return moduleDto;
		}

		public ModuleDto GetDto(SqlDataReader sdr)
		{
			return new ModuleDto
			{
				Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
				Name = sdr.GetString(sdr.GetOrdinal("Name")),
				SequenceNo= sdr.GetInt32(sdr.GetOrdinal("SequenceNo"))
			};
		}
	}
}
