using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IPrivilegeDal
    {
        List<PrivilegeDto> Fetch();

        List<PrivilegeDto> FetchByMenuId(Guid MenuId);

        PrivilegeDto IsSequenceNoAlreadyPresent(PrivilegeDto privilegeDto);

        PrivilegeDto FetchById(Guid Id);

        PrivilegeDto IsPrivilegeAlreadyPresent(PrivilegeDto roleDto);

        PrivilegeDto Insert(PrivilegeDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        PrivilegeDto Update(PrivilegeDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        PrivilegeDto Delete(PrivilegeDto roleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
