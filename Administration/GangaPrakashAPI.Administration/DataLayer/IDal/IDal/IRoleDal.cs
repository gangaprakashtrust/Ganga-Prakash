using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IRoleDal
    {
        List<RoleDto> Fetch();

        List<RoleDto> FetchByApplicationUserId(Guid ApplicationUserId);

        RoleDto FetchById(Guid Id);

        RoleDto IsRoleAlreadyPresent(RoleDto roleDto);

        RoleDto Insert(RoleDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleDto Update(RoleDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleDto Delete(RoleDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
