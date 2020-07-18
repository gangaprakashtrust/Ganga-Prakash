using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IInternalChatDal
    {
        List<InternalChatDto> FetchByApplicationUserId(Guid ApplicationUserId);

        InternalChatDto Insert(InternalChatDto internalChatDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
