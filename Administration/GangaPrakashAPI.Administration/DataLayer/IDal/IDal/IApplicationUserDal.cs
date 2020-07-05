using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IApplicationUserDal
    {
        List<ApplicationUserDto> Fetch();

        ApplicationUserDto FetchById(Guid Id);

        String GetApplicationUserIdBySystemUserId(Guid SystemUserId);

        ApplicationUserDto IsApplicationUserAlreadyPresent(ApplicationUserDto moduleDto);

        ApplicationUserDto Insert(ApplicationUserDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        ApplicationUserDto Update(ApplicationUserDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        ApplicationUserDto Delete(ApplicationUserDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
