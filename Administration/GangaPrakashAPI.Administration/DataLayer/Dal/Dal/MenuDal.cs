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
	public class MenuDal : IMenuDal
	{

		public List<MenuDto> Fetch()
		{
			List<MenuDto> result = new List<MenuDto>();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(@" Select M.Id,M.Name,M.Controller,M.Action,M.Area,M.SequenceNo,M.ParentId,M.ModuleId,MO.Name as Module,
											   CASE WHEN PM.Name IS NULL THEN '-' ELSE PM.Name END as ParentMenu from Menu M 
											   Inner Join Module Mo On Mo.Id=M.ModuleId And M.IsActive=1 And MO.IsActive=1
											   Left Join Menu PM On M.ParentId=PM.Id And PM.IsActive=1 And M.IsActive=1
											   Order By M.SequenceNo ASC", con);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				result.Add(GetMenuDtoWithModuleName(dr));
			}
			con.Close();
			return result;
		}

		public List<MenuDto> FetchParentMenuList()
		{
			List<MenuDto> result = new List<MenuDto>();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(@" Select M.Id,M.Name from Menu M Where M.ParentId=@emptyguid And M.IsActive=1 Order By M.SequenceNo ASC", con);
			cmd.Parameters.AddWithValue("@emptyguid", Guid.Empty);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				result.Add(GetParentMenuDto(dr));
			}
			con.Close();
			return result;
		}
		public MenuDto IsMenuAlreadyPresent(MenuDto menuDto)
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name from Menu M Where Upper(Trim(M.Name))=@name and M.Id<>@id And M.ModuleId=@moduleid and ParentId=@parentid And M.IsActive=1", con);
			cmd.Parameters.AddWithValue("@id", menuDto.Id);
			cmd.Parameters.AddWithValue("@moduleid", menuDto.ModuleId);
			cmd.Parameters.AddWithValue("@parentid", menuDto.ParentId??Guid.Empty);
			cmd.Parameters.AddWithValue("@name", menuDto.Name.Trim().ToUpper());
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				menuDto.ErrorCount = 1;
				menuDto.ErrorMessage = "Menu already present";
			}
			con.Close();
			return menuDto;
		}

		public MenuDto IsSequenceNoAlreadyPresent(MenuDto menuDto)
		{
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name from Menu M Where M.SequenceNo=@sequenceno and M.Id<>@id and M.ModuleId=@moduleid and ParentId=@parentid and M.IsActive=1", con);
			cmd.Parameters.AddWithValue("@id", menuDto.Id);
			cmd.Parameters.AddWithValue("@moduleid", menuDto.ModuleId);
			cmd.Parameters.AddWithValue("@parentid", menuDto.ParentId ?? Guid.Empty);
			cmd.Parameters.AddWithValue("@sequenceno", menuDto.SequenceNo);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				menuDto.ErrorCount = 1;
				menuDto.ErrorMessage = "Sequence No. already present";
			}
			con.Close();
			return menuDto;
		}

		public MenuDto FetchById(Guid Id)
		{
			MenuDto result = new MenuDto();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(" Select M.Id,M.Name,M.SequenceNo,M.Controller,M.Action,M.Area,M.SequenceNo,M.ParentId,M.ModuleId from Menu M Where M.Id=@id and M.IsActive=1", con);
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

		public MenuDto Insert(MenuDto menuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			SqlCommand cmd = new SqlCommand(" Insert Into Menu(Name,SequenceNo,Controller,Action,Area,ParentId,ModuleId,IsActive) Output Inserted.Id Values(@name,@sequenceno,@controller,@action,@area,@parentid,@moduleid,@isactive) ", con);
			if (transcon != null)
			{
				cmd.Transaction = trans;
			}
			cmd.Parameters.AddWithValue("@name", menuDto.Name);
			cmd.Parameters.AddWithValue("@controller", menuDto.Controller);
			cmd.Parameters.AddWithValue("@action", menuDto.Action);
			cmd.Parameters.AddWithValue("@area", menuDto.Area);
			cmd.Parameters.AddWithValue("@parentid", menuDto.ParentId??Guid.Empty);
			cmd.Parameters.AddWithValue("@moduleid", menuDto.ModuleId);
			cmd.Parameters.AddWithValue("@sequenceno", menuDto.SequenceNo);
			cmd.Parameters.AddWithValue("@isactive", menuDto.IsActive);

			Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
			menuDto.Id = InsertedId;
			if (transcon == null)
			{
				con.Close();
			}
			return menuDto;
		}

		public MenuDto Update(MenuDto menuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			SqlCommand cmd = new SqlCommand(" Update Menu set Name=@name,SequenceNo=@sequenceno,Controller=@controller,Action=@action,Area=@area,ParentId=@parentId,ModuleId=@moduleId,IsActive=@isactive Where Id=@id ", con);
			if (transcon != null)
			{
				cmd.Transaction = trans;
			}
			cmd.Parameters.AddWithValue("@id", menuDto.Id);
			cmd.Parameters.AddWithValue("@name", menuDto.Name);
			cmd.Parameters.AddWithValue("@controller", menuDto.Controller);
			cmd.Parameters.AddWithValue("@action", menuDto.Action);
			cmd.Parameters.AddWithValue("@area", menuDto.Area);
			cmd.Parameters.AddWithValue("@parentid", menuDto.ParentId ?? Guid.Empty);
			cmd.Parameters.AddWithValue("@moduleid", menuDto.ModuleId);
			cmd.Parameters.AddWithValue("@sequenceno", menuDto.SequenceNo);
			cmd.Parameters.AddWithValue("@isactive", menuDto.IsActive);
			Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
			if (transcon == null)
			{
				con.Close();
			}
			return menuDto;
		}

		public MenuDto Delete(MenuDto menuDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
			SqlCommand cmd = new SqlCommand(" Update Menu set IsActive=@isactive Where Id=@id ", con);
			if (transcon != null)
			{
				cmd.Transaction = trans;
			}
			cmd.Parameters.AddWithValue("@id", menuDto.Id);
			cmd.Parameters.AddWithValue("@isactive", menuDto.IsActive);
			Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
			if (transcon == null)
			{
				con.Close();
			}
			return menuDto;
		}

		public MenuDto GetDto(SqlDataReader sdr)
		{
			return new MenuDto
			{
				Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
				Name = sdr.GetString(sdr.GetOrdinal("Name")),
				Controller = sdr.GetString(sdr.GetOrdinal("Controller")),
				Action = sdr.GetString(sdr.GetOrdinal("Action")),
				Area = sdr.GetString(sdr.GetOrdinal("Area")),
				ParentId = sdr.GetGuid(sdr.GetOrdinal("ParentId")),
				ModuleId = sdr.GetGuid(sdr.GetOrdinal("ModuleId")),
				SequenceNo = sdr.GetInt32(sdr.GetOrdinal("SequenceNo"))
			};
		}

		public MenuDto GetMenuDtoWithModuleName(SqlDataReader sdr)
		{
			return new MenuDto
			{
				Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
				Name = sdr.GetString(sdr.GetOrdinal("Name")),
				Module = sdr.GetString(sdr.GetOrdinal("Module")),
				ParentMenu = sdr.GetString(sdr.GetOrdinal("ParentMenu")),
				Controller = sdr.GetString(sdr.GetOrdinal("Controller")),
				Action = sdr.GetString(sdr.GetOrdinal("Action")),
				Area = sdr.GetString(sdr.GetOrdinal("Area")),
				ParentId = sdr.GetGuid(sdr.GetOrdinal("ParentId")),
				ModuleId = sdr.GetGuid(sdr.GetOrdinal("ModuleId")),
				SequenceNo = sdr.GetInt32(sdr.GetOrdinal("SequenceNo"))
			};
		}

		public MenuDto GetParentMenuDto(SqlDataReader sdr)
		{
			return new MenuDto
			{
				Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
				Name = sdr.GetString(sdr.GetOrdinal("Name"))
			};
		}
	}
}
