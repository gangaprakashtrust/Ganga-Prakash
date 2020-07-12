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

        public List<MenuDto> FetchParentList()
        {
            List<MenuDto> result = new List<MenuDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select Id,Name,Case when ParentId='00000000-0000-0000-0000-000000000000' then Id else ParentId end as ParentId,ModuleId,Module,IsParent,0 as IsChecked,SequenceNo from
                                               (Select M.Id,M.Name,M.ParentId,MO.Id as ModuleId,MO.Name as Module,Case When M.ParentId='00000000-0000-0000-0000-000000000000'then 1 else 0 end as IsParent,M.SequenceNo from Menu M
                                                Inner Join Module MO on MO.IsACtive=1 And M.IsActive=1 And MO.Id=M.ModuleId) PM order by ParentId ASC,IsParent DESC", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetParentMenuDto(dr));
            }
            con.Close();
            return result;
        }

        public Boolean IsMenuReferencePresent(Guid MenuId)
        {
            Boolean IsMenuReferencePresent = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select RM.Id from RoleMenu RM Where RM.MenuId=@menuid and RM.IsActive=1", con);
            cmd.Parameters.AddWithValue("@menuid", MenuId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                IsMenuReferencePresent = true;
            }
            con.Close();
            return IsMenuReferencePresent;
        }

        public List<MenuDto> FetchParentListByRoleId(Guid RoleId)
        {
            List<MenuDto> result = new List<MenuDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select PM.Id,PM.Name,Case when PM.ParentId='00000000-0000-0000-0000-000000000000' then PM.Id else PM.ParentId end as ParentId,PM.ModuleId,PM.Module,PM.IsParent,PM.IsActive,case When(RM.Id is null) then 0 else 1 End as IsChecked,PM.SequenceNo from
                                               (Select M.Id,M.Name,M.ParentId,MO.Id as ModuleId,MO.Name as Module,Case When M.ParentId='00000000-0000-0000-0000-000000000000'then 1 else 0 end as IsParent,M.SequenceNo,M.IsActive from Menu M
                                               Inner Join Module MO on MO.IsACtive=1 And M.IsActive=1 And MO.Id=M.ModuleId) PM 
                                               Left Outer join RoleMenu RM On RM.MenuId=PM.Id 
                                               And RM.RoleId=@roleid And PM.IsActive=1 And RM.IsActive=1
                                               order by ParentId ASC,IsParent DESC", con);
            cmd.Parameters.AddWithValue("@roleid", RoleId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetParentMenuDto(dr));
            }
            con.Close();
            return result;
        }

        public List<MenuDto> FetchUserMenuBasedOnPrivilege(String Controller, String Action, String Area, Guid ApplicationUserId)
        {
            List<MenuDto> result = new List<MenuDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"  Select Distinct M.Id,M.Name,M.Controller,M.Action,M.Area,M.SequenceNo,M.ParentId,M.ModuleId from Menu M
                                                Inner Join RoleMenu RM on RM.MenuId=M.Id ANd RM.IsActive=1 And M.IsActive=1 And M.Controller=@controller And M.Area=@area
                                                Inner Join UserRole UR On UR.RoleId=RM.RoleId And UR.ApplicationUserId=@applicationuserid And UR.IsActive=1 And RM.IsActive=1
                                                Inner Join RoleMenuPrivilege RMP On RMP.RoleMenuId=RM.Id And RM.IsActive=1 And RMP.IsACtive=1
                                                Inner Join Privilege P On RMP.PrivilegeId=P.Id ANd RMP.IsActive=1 And P.IsActive=1 And P.Name=@action", con);
            cmd.Parameters.AddWithValue("@controller", Controller);
            cmd.Parameters.AddWithValue("@area", Area);
            cmd.Parameters.AddWithValue("@applicationuserid", ApplicationUserId);
            cmd.Parameters.AddWithValue("@action", Action);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public List<UserAccessMenuDto> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            List<UserAccessMenuDto> result = new List<UserAccessMenuDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@"  Select M.Id,M.Action,M.Controller,M.Area,M.Name,MO.Name as Module,M.ModuleId,M.SequenceNo,Case When M.ParentId='00000000-0000-0000-0000-000000000000' then M.Id else M.ParentId end as ParentId,Case When M.ParentId='00000000-0000-0000-0000-000000000000' then 1 else 0 end as IsParent from Menu M
                                                Inner Join RoleMenu RM on RM.MenuId=M.Id And RM.IsACtive=1
                                                Inner Join UserRole UR On UR.RoleId=RM.RoleId And UR.ApplicationUserId=@applicationuserid And UR.IsACtive=1
                                                Inner Join Module MO On MO.Id=M.ModuleId ANd MO.IsACtive=1 And M.IsACtive=1
                                                Group By ModuleId,M.Name,M.SequenceNo,ParentId,M.Id,MO.Name,M.Action,M.Controller,M.Area
                                                Order By ModuleId,ParentId,IsParent Desc,M.SequenceNo", con);
            cmd.Parameters.AddWithValue("@applicationuserid", ApplicationUserId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetUserAccessMenuDto(dr));
            }
            con.Close();
            return result;
        }

        public List<MenuDto> GetParentListByModuleId(Guid ModuleId)
		{
			List<MenuDto> result = new List<MenuDto>();
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
			SqlCommand cmd = new SqlCommand(@" Select M.Id,M.Name from Menu M Where M.ParentId=@emptyguid And M.ModuleId=@moduleid And M.IsActive=1 Order By M.SequenceNo ASC", con);
			cmd.Parameters.AddWithValue("@emptyguid", Guid.Empty);
            cmd.Parameters.AddWithValue("@moduleid", ModuleId);
            con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				result.Add(GetParentListDto(dr));
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
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                ParentId = sdr.GetGuid(sdr.GetOrdinal("ParentId")),
                Module = sdr.GetString(sdr.GetOrdinal("Module")),
                ModuleId = sdr.GetGuid(sdr.GetOrdinal("ModuleId")),
                SequenceNo = sdr.GetInt32(sdr.GetOrdinal("SequenceNo")),
                IsParent = ((sdr.GetInt32(sdr.GetOrdinal("IsParent"))) == 1) ? true : false,
                IsChecked = ((sdr.GetInt32(sdr.GetOrdinal("IsChecked"))) == 1) ? true : false
            };
		}

        public MenuDto GetParentListDto(SqlDataReader sdr)
        {
            return new MenuDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name"))
            };
        }

        public UserAccessMenuDto GetUserAccessMenuDto(SqlDataReader sdr)
        {
            return new UserAccessMenuDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Action = sdr.GetString(sdr.GetOrdinal("Action")),
                Controller = sdr.GetString(sdr.GetOrdinal("Controller")),
                Area = sdr.GetString(sdr.GetOrdinal("Area")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                Module = sdr.GetString(sdr.GetOrdinal("Module")),
                ModuleId = sdr.GetGuid(sdr.GetOrdinal("ModuleId")),
                SequenceNo = sdr.GetInt32(sdr.GetOrdinal("SequenceNo")),
                ParentId = sdr.GetGuid(sdr.GetOrdinal("ParentId")),
                IsParent = ((sdr.GetInt32(sdr.GetOrdinal("IsParent"))) == 1) ? true : false,
            };
        }
    }
}
