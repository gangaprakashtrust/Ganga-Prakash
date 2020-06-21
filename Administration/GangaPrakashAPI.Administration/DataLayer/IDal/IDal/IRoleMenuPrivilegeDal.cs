using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IRoleMenuPrivilegeDal
    {
        List<RoleMenuPrivilegeDto> FetchByRoleId(Guid RoleId);

        RoleMenuPrivilegeDto Insert(RoleMenuPrivilegeDto roleMenuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleMenuPrivilegeDto Update(RoleMenuPrivilegeDto roleMenuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleMenuPrivilegeDto Delete(RoleMenuPrivilegeDto roleMenuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

    }
}
