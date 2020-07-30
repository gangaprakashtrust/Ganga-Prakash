using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface IGenderDal
    {
        List<GenderDto> Fetch();

        GenderDto FetchById(Guid Id);

        GenderDto IsGenderAlreadyPresent(GenderDto genderDto);

        GenderDto Insert(GenderDto genderDto, SqlConnection transcon = null, SqlTransaction trans = null);

        GenderDto Update(GenderDto genderDto, SqlConnection transcon = null, SqlTransaction trans = null);

        GenderDto Delete(GenderDto genderDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
