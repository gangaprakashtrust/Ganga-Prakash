using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface IIdentityTypeDal
    {
        List<IdentityTypeDto> Fetch();

        IdentityTypeDto FetchById(Guid Id);

        IdentityTypeDto IsIdentityTypeAlreadyPresent(IdentityTypeDto identityTypeDto);

        IdentityTypeDto Insert(IdentityTypeDto identityTypeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        IdentityTypeDto Update(IdentityTypeDto identityTypeDto, SqlConnection transcon = null, SqlTransaction trans = null);

        IdentityTypeDto Delete(IdentityTypeDto identityTypeDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
