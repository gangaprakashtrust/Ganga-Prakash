using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Configuration.Dal;
using GangaPrakashAPI.Configuration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Configuration.Persister
{
    public class DoctorDepartmentPersister
    {
        public DoctorDepartment Insert(DoctorDepartment doctorDepartment, SqlConnection con = null, SqlTransaction trans = null)
        {
            IDoctorDepartmentDal IdoctorDepartmentDal = new DoctorDepartmentDal();
            DoctorDepartmentDto doctorDepartmentDto = new DoctorDepartmentDto
            {
                DoctorId = doctorDepartment.DoctorId,
                DepartmentId = doctorDepartment.DepartmentId,
                IsActive = true
            };
            IdoctorDepartmentDal.Insert(doctorDepartmentDto, con, trans);
            doctorDepartment.Id = doctorDepartmentDto.Id;
            return doctorDepartment;
        }

        public DoctorDepartment Update(DoctorDepartment doctorDepartment, SqlConnection con = null, SqlTransaction trans = null)
        {
            IDoctorDepartmentDal IdoctorDepartmentDal = new DoctorDepartmentDal();
            DoctorDepartmentDto doctorDepartmentDto = new DoctorDepartmentDto
            {
                Id = doctorDepartment.Id,
                DoctorId = doctorDepartment.DoctorId,
                DepartmentId = doctorDepartment.DepartmentId,
                IsActive = true
            };
            IdoctorDepartmentDal.Update(doctorDepartmentDto, con, trans);
            doctorDepartment.Id = doctorDepartmentDto.Id;
            return doctorDepartment;
        }

        public DoctorDepartment Delete(DoctorDepartment doctorDepartment, SqlConnection con = null, SqlTransaction trans = null)
        {
            IDoctorDepartmentDal IdoctorDepartmentDal = new DoctorDepartmentDal();
            DoctorDepartmentDto doctorDepartmentDto = new DoctorDepartmentDto
            {
                Id = doctorDepartment.Id,
                IsActive = false
            };
            IdoctorDepartmentDal.Delete(doctorDepartmentDto, con, trans);
            doctorDepartment.Id = doctorDepartmentDto.Id;

            return doctorDepartment;
        }

        public static DoctorDepartment Get()
        {
            DoctorDepartment doctorDepartment = new DoctorDepartment();
            return doctorDepartment;
        }

        public static DoctorDepartmentPersister GetPersister()
        {
            DoctorDepartmentPersister doctorDepartmentPersister = new DoctorDepartmentPersister();
            return doctorDepartmentPersister;
        }
    }
}
