using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Configuration.IDal;
using GangaPrakashAPI.Configuration.Dal;


namespace GangaPrakashAPI.Configuration.Persister
{
    public class DepartmentList
    {
        public static List<Department> GetList()
        {
            return Fetch();
        }

        private static List<Department> Fetch()
        {
            IDepartmentDal IdepartmentDal = new DepartmentDal();
            List<Department> departmentList = new List<Department>();
            foreach (var item in IdepartmentDal.Fetch())
            {
                Department department = new Department
                {
                    Id = item.Id,
                    Name = item.Name
                };
                departmentList.Add(department);
            }
            return departmentList;
        }
    }
}
