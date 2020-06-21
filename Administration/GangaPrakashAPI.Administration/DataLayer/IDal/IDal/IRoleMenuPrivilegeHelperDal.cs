using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IRoleMenuPrivilegeHelperDal
    {
        List<RoleMenuPrivilegeHelperDto> FetchByRoleId(Guid RoleId);
    }
}
