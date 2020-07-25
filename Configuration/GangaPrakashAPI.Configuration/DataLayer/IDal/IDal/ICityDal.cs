using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface ICityDal
    {
        List<CityDto> Fetch();

        CityDto FetchById(Guid Id);

        CityDto IsCityAlreadyPresent(CityDto cityDto);

        CityDto Insert(CityDto cityDto, SqlConnection transcon = null, SqlTransaction trans = null);

        CityDto Update(CityDto cityDto, SqlConnection transcon = null, SqlTransaction trans = null);

        CityDto Delete(CityDto cityDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
