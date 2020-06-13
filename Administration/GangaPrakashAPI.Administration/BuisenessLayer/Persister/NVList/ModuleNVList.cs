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
    public static class ModuleNVList
    {
        public static List<KeyValuePair<Guid, String>> GetList()
        {
            return Fetch();
        }

        private static List<KeyValuePair<Guid, String>> Fetch()
        {
            IModuleDal ImoduleDal = new ModuleDal();
            List<KeyValuePair<Guid, String>> moduleList = new List<KeyValuePair<Guid, String>>();
            foreach (var item in ImoduleDal.Fetch())
            {
                moduleList.Add(new KeyValuePair<Guid, string>(item.Id, item.Name));
            }
            return moduleList;
        }
    }
}
