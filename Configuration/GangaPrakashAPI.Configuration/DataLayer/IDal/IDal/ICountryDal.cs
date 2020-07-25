using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface ICountryDal
    {
        List<CountryDto> Fetch();

        CountryDto FetchById(Guid Id);

        CountryDto IsCountryAlreadyPresent(CountryDto countryDto);

        Boolean IsStateReferencePresent(Guid CountryId);

        CountryDto Insert(CountryDto countryDto, SqlConnection transcon = null, SqlTransaction trans = null);

        CountryDto Update(CountryDto countryDto, SqlConnection transcon = null, SqlTransaction trans = null);

        CountryDto Delete(CountryDto countryDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
