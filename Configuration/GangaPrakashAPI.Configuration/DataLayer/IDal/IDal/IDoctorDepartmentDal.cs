using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public interface IDoctorDepartmentDal
    {
        List<DoctorDepartmentDto> Fetch();

        DoctorDepartmentDto Insert(DoctorDepartmentDto doctorDepartmentDto, SqlConnection transcon = null, SqlTransaction trans = null);

        DoctorDepartmentDto Update(DoctorDepartmentDto doctorDepartmentDto, SqlConnection transcon = null, SqlTransaction trans = null);

        DoctorDepartmentDto Delete(DoctorDepartmentDto doctorDepartmentDto, SqlConnection transcon = null, SqlTransaction trans = null);
    }
}
