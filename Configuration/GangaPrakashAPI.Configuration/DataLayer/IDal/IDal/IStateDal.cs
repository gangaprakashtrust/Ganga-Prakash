using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface IStateDal
    {
        List<StateDto> Fetch();

        List<StateDto> FetchByCountryId(Guid CountryId);

        StateDto FetchById(Guid Id);

        StateDto IsStateAlreadyPresent(StateDto stateDto);

        StateDto Insert(StateDto stateDto, SqlConnection transcon = null, SqlTransaction trans = null);

        StateDto Update(StateDto stateDto, SqlConnection transcon = null, SqlTransaction trans = null);

        StateDto Delete(StateDto stateDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
