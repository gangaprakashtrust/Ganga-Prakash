using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Persister
{
    public class InternalChatPersister
    {
        public InternalChat Insert(InternalChat InternalChat, SqlConnection con = null, SqlTransaction trans = null)
        {
            IInternalChatDal IInternalChatDal = new InternalChatDal();
            InternalChatDto InternalChatDto = new InternalChatDto
            {
                ApplicationUserId = InternalChat.ApplicationUserId,
                Username = InternalChat.Username,
                Text = InternalChat.Text,
                IsActive = true
            };
            IInternalChatDal.Insert(InternalChatDto, con, trans);
            InternalChat.Id = InternalChatDto.Id;
            return InternalChat;
        }

        public static InternalChat Get()
        {
            InternalChat InternalChat = new InternalChat();
            return InternalChat;
        }

        public static InternalChatPersister GetPersister()
        {
            InternalChatPersister InternalChatPersister = new InternalChatPersister();
            return InternalChatPersister;
        }
    }
}
