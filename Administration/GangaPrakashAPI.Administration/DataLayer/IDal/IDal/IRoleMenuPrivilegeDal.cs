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

        Boolean Delete(Guid MenuId,Guid PrivilegeId, SqlConnection transcon = null, SqlTransaction trans = null);

        Boolean Delete(Guid RoleId, Guid MenuId,Guid RoleMenuId, SqlConnection transcon = null, SqlTransaction trans = null);

        Boolean Delete(Guid RoleId, SqlConnection transcon = null, SqlTransaction trans = null);

    }
}
