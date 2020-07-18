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
    public class InternalChatDal : IInternalChatDal
    {

        public List<InternalChatDto> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            List<InternalChatDto> result = new List<InternalChatDto>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GangaPrakashConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(" Select IC.ID,IC.ApplicationUserId,IC.Text,IC.Username,IC.DateTime,Case when IC.ApplicationUserId=@applicationuserid then 1 else 0 end as IsReceiver from InternalChat IC Where IC.IsActive=1 Order By IC.DateTime ASC ", con);
            cmd.Parameters.AddWithValue("@applicationuserid", ApplicationUserId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result.Add(GetDto(dr));
            }
            con.Close();
            return result;
        }

        public InternalChatDto Insert(InternalChatDto internalChatDto, SqlConnection transcon = null, SqlTransaction trans = null)
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
            SqlCommand cmd = new SqlCommand(" Insert Into InternalChat(ApplicationUserId,Text,Username,IsActive) Output Inserted.Id Values(@applicationuserid,@text,@username,@isactive) ", con);
            if (transcon != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@applicationuserid", internalChatDto.ApplicationUserId);
            cmd.Parameters.AddWithValue("@text", internalChatDto.Text);
            cmd.Parameters.AddWithValue("@username", internalChatDto.Username);
            cmd.Parameters.AddWithValue("@isactive", internalChatDto.IsActive);

            Guid InsertedId = Guid.Parse(cmd.ExecuteScalar().ToString());
            internalChatDto.Id = InsertedId;
            if (transcon == null)
            {
                con.Close();
            }
            return internalChatDto;
        }

        public InternalChatDto GetDto(SqlDataReader sdr)
        {
            return new InternalChatDto
            {
                Id = sdr.GetGuid(sdr.GetOrdinal("Id")),
                ApplicationUserId = sdr.GetGuid(sdr.GetOrdinal("ApplicationUserId")),
                Text = sdr.GetString(sdr.GetOrdinal("Text")),
                Username = sdr.GetString(sdr.GetOrdinal("Username")),
                DateTime= sdr.GetDateTime(sdr.GetOrdinal("DateTime")),
                IsReceiver = ((sdr.GetInt32(sdr.GetOrdinal("IsReceiver"))) == 1) ? true : false,
            };
        }
    }
}
