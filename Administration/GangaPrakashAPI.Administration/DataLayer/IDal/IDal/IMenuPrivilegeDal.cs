using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IMenuPrivilegeDal
    {
        List<MenuPrivilegeDto> FetchByMenuId(Guid MenuId);

        MenuPrivilegeDto Insert(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        MenuPrivilegeDto Update(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        MenuPrivilegeDto Delete(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        MenuPrivilegeDto DeletePrivilegeByMenu(MenuPrivilegeDto menuPrivilegeDto, SqlConnection transcon = null, SqlTransaction trans = null);

    }
}
