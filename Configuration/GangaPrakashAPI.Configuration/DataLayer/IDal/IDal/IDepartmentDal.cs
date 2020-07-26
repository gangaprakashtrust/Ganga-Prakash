using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface IDepartmentDal
    {
        List<DepartmentDto> Fetch();

        DepartmentDto FetchById(Guid Id);

        DepartmentDto IsDepartmentAlreadyPresent(DepartmentDto departmentDto);

        DepartmentDto Insert(DepartmentDto departmentDto, SqlConnection transcon = null, SqlTransaction trans = null);

        DepartmentDto Update(DepartmentDto departmentDto, SqlConnection transcon = null, SqlTransaction trans = null);

        DepartmentDto Delete(DepartmentDto departmentDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
