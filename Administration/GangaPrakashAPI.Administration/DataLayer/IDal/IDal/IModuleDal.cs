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

        ModuleDto FetchById(Guid Id);

        ModuleDto IsModuleAlreadyPresent(ModuleDto moduleDto);

        ModuleDto IsSequenceNoAlreadyPresent(ModuleDto moduleDto);

        ModuleDto Insert(ModuleDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        ModuleDto Update(ModuleDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);

        ModuleDto Delete(ModuleDto moduleDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
