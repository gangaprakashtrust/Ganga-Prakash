using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public interface IModuleDal
    {
        List<ModuleDto> Fetch();

        ModuleDto FetchById(Int32 Id);

        ModuleDto Insert(ModuleDto ModuleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        ModuleDto Update(ModuleDto ModuleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        ModuleDto Delete(ModuleDto ModuleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
