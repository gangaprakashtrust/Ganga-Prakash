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

        RoleDto FetchById(Guid Id);

        RoleDto IsRoleAlreadyPresent(RoleDto CarTypeDto);

        RoleDto Insert(RoleDto RoleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleDto Update(RoleDto RoleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        RoleDto Delete(RoleDto RoleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
