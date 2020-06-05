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
			List<ModuleDto> Result = new List<ModuleDto>();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name,M.SequenceNo from Module M Order By M.SequenceNo ASC", con);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				Result.Add(GetDto(dr));
			}
			con.Close();
			return Result;
		}

		public ModuleDto IsModuleAlreadyPresent(ModuleDto ModuleDto)
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name from Module M Where Upper(Trim(M.Name))=@name and M.Id<>@id ", con);
			cmd.Parameters.AddWithValue("@id", ModuleDto.Id);
			cmd.Parameters.AddWithValue("@name", ModuleDto.Name.Trim().ToUpper());
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				ModuleDto.ErrorCount = 1;
				ModuleDto.ErrorMessage = "Module already present";
			}
			con.Close();
			return ModuleDto;
		}

		public ModuleDto IsSequenceNoAlreadyPresent(ModuleDto ModuleDto)
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name from Module M Where M.SequenceNo=@sequenceno and M.Id<>@id ", con);
			cmd.Parameters.AddWithValue("@id", ModuleDto.Id);
			cmd.Parameters.AddWithValue("@sequenceno", ModuleDto.SequenceNo);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				ModuleDto.ErrorCount = 1;
				ModuleDto.ErrorMessage = "Sequence No. already present";
			}
			con.Close();
			return ModuleDto;
		}

		public ModuleDto FetchById(Guid Id)
		{
			ModuleDto Result = new ModuleDto();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name,M.SequenceNo from Module M Where M.Id=@id ", con);
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

		public ModuleDto Insert(ModuleDto ModuleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			cmd.Parameters.AddWithValue("@name", ModuleDto.Name);
			cmd.Parameters.AddWithValue("@sequenceno", ModuleDto.SequenceNo);
			cmd.Parameters.AddWithValue("@isactive", ModuleDto.IsActive);

			Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
			ModuleDto.Id = InsertedId;
			if (transcon == null)
			{
				con.Close();
			}
			return ModuleDto;
		}

		public ModuleDto Update(ModuleDto ModuleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			cmd.Parameters.AddWithValue("@id", ModuleDto.Id);
			cmd.Parameters.AddWithValue("@name", ModuleDto.Name);
			cmd.Parameters.AddWithValue("@sequenceno", ModuleDto.SequenceNo);
			cmd.Parameters.AddWithValue("@isactive", ModuleDto.IsActive);
			Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
			if (transcon == null)
			{
				con.Close();
			}
			return ModuleDto;
		}

		public ModuleDto Delete(ModuleDto ModuleDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			cmd.Parameters.AddWithValue("@id", ModuleDto.Id);
			cmd.Parameters.AddWithValue("@isactive", ModuleDto.IsActive);
			Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
			if (transcon == null)
			{
				con.Close();
			}
			return ModuleDto;
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
