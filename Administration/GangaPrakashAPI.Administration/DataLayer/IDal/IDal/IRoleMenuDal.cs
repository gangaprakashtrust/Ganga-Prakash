using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IRoleMenuDal
    {
        List<RoleMenuDto> FetchByRoleId(Guid RoleId);

        RoleMenuDto Insert(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleMenuDto Update(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleMenuDto Delete(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleMenuDto DeleteRoleMenuByRole(RoleMenuDto roleMenuDto, SqlConnection transcon = null, SqlTransaction trans = null);

    }
}
