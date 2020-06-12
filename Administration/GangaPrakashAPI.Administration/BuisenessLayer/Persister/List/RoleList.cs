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
            IRoleDal IroleDal = new RoleDal();
            List<Role> roleList = new List<Role>();
            foreach (var item in IroleDal.Fetch())
            {
                Role role = new Role
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                roleList.Add(role);
            }
            return roleList;
        }
    }
}
