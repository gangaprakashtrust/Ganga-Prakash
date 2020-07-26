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
    public class DepartmentPersister
    {
        public Department Insert(Department department, SqlConnection con = null, SqlTransaction trans = null)
        {
            IDepartmentDal IdepartmentDal = new DepartmentDal();
            DepartmentDto departmentDto = new DepartmentDto
            {
                Name = department.Name,
                IsActive = true
            };
            IdepartmentDal.IsDepartmentAlreadyPresent(departmentDto);
            if (departmentDto.ErrorCount == 0)
            {
                IdepartmentDal.Insert(departmentDto, con, trans);
                department.Id = departmentDto.Id;

            }
            else
            {
                department.IsError = true;
                department.ErrorMessage = departmentDto.ErrorMessage;
                department.ErrorMessageFor = "Name";

            }
            return department;
        }

        public Department Update(Department department, SqlConnection con = null, SqlTransaction trans = null)
        {
            IDepartmentDal IdepartmentDal = new DepartmentDal();
            DepartmentDto departmentDto = new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                IsActive = true
            };
            IdepartmentDal.IsDepartmentAlreadyPresent(departmentDto);
            if (departmentDto.ErrorCount == 0)
            {
                IdepartmentDal.Update(departmentDto, con, trans);
                department.Id = departmentDto.Id;
            }
            else
            {
                department.IsError = true;
                department.ErrorMessage = departmentDto.ErrorMessage;
                department.ErrorMessageFor = "Name";

            }
            return department;
        }

        public Department Delete(Department department, SqlConnection con = null, SqlTransaction trans = null)
        {
            IDepartmentDal IdepartmentDal = new DepartmentDal();
            DepartmentDto departmentDto = new DepartmentDto
            {
                Id = department.Id,
                IsActive = false
            };
            IdepartmentDal.Delete(departmentDto, con, trans);
            department.Id = departmentDto.Id;

            return department;
        }

        public static Department GetDepartment(Guid Id)
        {
            IDepartmentDal IdepartmentDal = new DepartmentDal();
            DepartmentDto departmentDto = IdepartmentDal.FetchById(Id);
            Department department = new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name
            };
            return department;
        }

        public static Department Get()
        {
            Department department = new Department();
            return department;
        }

        public static DepartmentPersister GetPersister()
        {
            DepartmentPersister departmentPersister = new DepartmentPersister();
            return departmentPersister;
        }
    }
}
