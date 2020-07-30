using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface IAddressDal
    {
        AddressDto FetchById(Guid Id);

        AddressDto Insert(AddressDto addressDto, SqlConnection transcon = null, SqlTransaction trans = null);

        AddressDto Update(AddressDto addressDto, SqlConnection transcon = null, SqlTransaction trans = null);

        AddressDto Delete(AddressDto addressDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
