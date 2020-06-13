using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IMenuDal
    {
        List<MenuDto> Fetch();

        List<MenuDto> FetchParentMenuList();

        MenuDto FetchById(Guid Id);

        MenuDto IsMenuAlreadyPresent(MenuDto moduleDto);

        MenuDto IsSequenceNoAlreadyPresent(MenuDto moduleDto);

        MenuDto Insert(MenuDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        MenuDto Update(MenuDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        MenuDto Delete(MenuDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
