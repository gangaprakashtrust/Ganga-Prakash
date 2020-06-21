using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;

namespace GangaPrakashAPI.Administration.Persister
{
    public static class RoleNVList
    {
        public static List<KeyValuePair<Guid, String>> GetList()
        {
            return Fetch();
        }

        private static List<KeyValuePair<Guid, String>> Fetch()
        {
            IRoleDal IroleDal = new RoleDal();
            List<KeyValuePair<Guid, String>> roleList = new List<KeyValuePair<Guid, String>>();
            foreach (var item in IroleDal.Fetch())
            {
                roleList.Add(new KeyValuePair<Guid, string>(item.Id, item.Name));
            }
            return roleList;
        }
    }
}
