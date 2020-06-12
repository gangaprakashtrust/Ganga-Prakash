using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Administration.Dal;


namespace GangaPrakashAPI.Administration.Persister
{
    public class RoleList
    {
        public static List<Role> GetList()
        {
            return Fetch();
        }

        private static List<Role> Fetch()
        {
            IRoleDal IRoleDal = new RoleDal();
            List<Role> RoleList = new List<Role>();
            foreach (var item in IRoleDal.Fetch())
            {
                Role module = new Role
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                RoleList.Add(module);
            }
            return RoleList;
        }
    }
}
