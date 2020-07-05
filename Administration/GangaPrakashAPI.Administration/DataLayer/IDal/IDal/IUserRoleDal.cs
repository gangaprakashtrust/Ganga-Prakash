using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IUserRoleDal
    {
        List<UserRoleDto> Fetch();

        List<UserRoleDto> FetchByApplicationUserId(Guid ApplicationUserId);

        UserRoleDto FetchById(Guid Id);

        UserRoleDto Insert(UserRoleDto userRoleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        UserRoleDto Update(UserRoleDto userRoleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        UserRoleDto Delete(UserRoleDto userRoleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        void Delete(ApplicationUserDto applicationUserDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
