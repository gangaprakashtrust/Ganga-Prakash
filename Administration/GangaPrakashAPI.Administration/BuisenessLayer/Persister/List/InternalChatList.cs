using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Administration.Dal;


namespace GangaPrakashAPI.Administration.Persister
{
    public class InternalChatList
    {
        public static List<InternalChat> GetListByApplicationUserId(Guid ApplicationUserId)
        {
            return FetchByApplicationUserId(ApplicationUserId);
        }

        private static List<InternalChat> FetchByApplicationUserId(Guid ApplicationUserId)
        {
            IInternalChatDal IiInternalChatDal = new InternalChatDal();
            List<InternalChat> iInternalChatList = new List<InternalChat>();
            foreach (var item in IiInternalChatDal.FetchByApplicationUserId(ApplicationUserId))
            {
                InternalChat iInternalChat = new InternalChat
                {
                    Id = item.Id,
                    ApplicationUserId = item.ApplicationUserId,
                    Username = item.Username,
                    Text = item.Text,
                    DateTime = item.DateTime,
                    IsReceiver=item.IsReceiver
                };
                iInternalChatList.Add(iInternalChat);
            }
            return iInternalChatList;
        }
    }
}
