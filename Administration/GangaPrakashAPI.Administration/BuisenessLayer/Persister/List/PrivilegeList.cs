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
    public class PrivilegeList
    {
        public static List<Privilege> GetList()
        {
            return Fetch();
        }

        private static List<Privilege> Fetch()
        {
            IPrivilegeDal IprivilegeDal = new PrivilegeDal();
            List<Privilege> privilegeList = new List<Privilege>();
            foreach (var item in IprivilegeDal.Fetch())
            {
                Privilege privilege = new Privilege
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                privilegeList.Add(privilege);
            }
            return privilegeList;
        }
    }
}
