﻿using GangaPrakashAPI.Administration.IDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.Dal
{
    public class PrivilegeDal : IPrivilegeDal
    {

        public List<PrivilegeDto> Fetch()
        {
            List<PrivilegeDto> result = new List<PrivilegeDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select P.Id,P.Name,P.SequenceNo from Privilege P Where P.IsActive=1 Order By P.SequenceNo  ASC", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public Boolean IsPrivilegeReferencePresent(Guid PrivilegeId)
        {
            Boolean IsPrivilegeReferencePresent = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select MP.Id from MenuPrivilege MP Where MP.PrivilegeId=@privilegeid and MP.IsActive=1", con);
            cmd.Parameters.AddWithValue("@privilegeid", PrivilegeId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                IsPrivilegeReferencePresent = true;
            }
            con.Close();
            return IsPrivilegeReferencePresent;
        }

        public List<PrivilegeDto> FetchByMenuId(Guid MenuId)
        {
            List<PrivilegeDto> result = new List<PrivilegeDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(@" Select P.Id,P.Name,P.SequenceNo,case When(MP.Id is null) then 0 else 1 End as IsChecked 
                                               from Privilege P
                                               Left Outer join MenuPrivilege MP On MP.PrivilegeId=P.Id 
                                               And MP.MenuId=@menuid And P.IsActive=1 And MP.IsActive=1
                                               Group By P.Id,P.Name,MP.Id,P.SequenceNo Order By P.SequenceNo ASC ", con);
            cmd.Parameters.AddWithValue("@menuid", MenuId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetMenuPrivilegeDto(dr));
            }
            con.Close();
            return result;
        }

        public PrivilegeDto IsPrivilegeAlreadyPresent(PrivilegeDto privilegeDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select P.Id,P.Name,P.SequenceNo from Privilege P Where Upper(Trim(P.Name))=@name and P.Id<>@id and P.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", privilegeDto.Id);
            cmd.Parameters.AddWithValue("@name", privilegeDto.Name.Trim().ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                privilegeDto.ErrorCount = 1;
                privilegeDto.ErrorMessage = "Privilege already present";
            }
            con.Close();
            return privilegeDto;
        }

        public PrivilegeDto IsSequenceNoAlreadyPresent(PrivilegeDto privilegeDto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select P.Id,P.Name from Privilege P Where P.SequenceNo=@sequenceno and P.Id<>@id and P.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", privilegeDto.Id);
            cmd.Parameters.AddWithValue("@sequenceno", privilegeDto.SequenceNo);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                privilegeDto.ErrorCount = 1;
                privilegeDto.ErrorMessage = "Sequence No. already present";
            }
            con.Close();
            return privilegeDto;
        }

        public PrivilegeDto FetchById(Guid Id)
        {
            PrivilegeDto result = new PrivilegeDto();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select P.Id,P.Name,P.SequenceNo from Privilege P Where P.Id=@id and P.IsActive=1", con);
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

        public PrivilegeDto Insert(PrivilegeDto privilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into Privilege(Name,SequenceNo,IsActive) Output Inserted.Id Values(@name,@sequenceno,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@name", privilegeDto.Name);
            cmd.Parameters.AddWithValue("@sequenceno", privilegeDto.SequenceNo);
            cmd.Parameters.AddWithValue("@isactive", privilegeDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            privilegeDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return privilegeDto;
        }

        public PrivilegeDto Update(PrivilegeDto privilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Privilege set Name=@name,SequenceNo=@sequenceno,IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", privilegeDto.Id);
            cmd.Parameters.AddWithValue("@name", privilegeDto.Name);
            cmd.Parameters.AddWithValue("@sequenceno", privilegeDto.SequenceNo);
            cmd.Parameters.AddWithValue("@isactive", privilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return privilegeDto;
        }

        public PrivilegeDto Delete(PrivilegeDto privilegeDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Update Privilege set IsActive=@isactive Where Id=@id ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@id", privilegeDto.Id);
            cmd.Parameters.AddWithValue("@isactive", privilegeDto.IsActive);
            Int32 IsDataAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (transcon == null)
            {
                con.Close();
            }
            return privilegeDto;
        }

        public PrivilegeDto GetDto(SqlDataReader sdr)
        {
            return new PrivilegeDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                SequenceNo = sdr.GetInt32(sdr.GetOrdinal("SequenceNo"))
            };
        }
        public PrivilegeDto GetMenuPrivilegeDto(SqlDataReader sdr)
        {
            return new PrivilegeDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                Name = sdr.GetString(sdr.GetOrdinal("Name")),
                SequenceNo = sdr.GetInt32(sdr.GetOrdinal("SequenceNo")),
                IsChecked = ((sdr.GetInt32(sdr.GetOrdinal("IsChecked")))==1)?true:false
            };
        }
    }
}
