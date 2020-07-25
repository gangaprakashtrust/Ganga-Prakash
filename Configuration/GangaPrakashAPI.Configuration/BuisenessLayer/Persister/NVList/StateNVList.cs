using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Configuration.Dal;
using GangaPrakashAPI.Configuration.IDal;

namespace GangaPrakashAPI.Configuration.Persister
{
    public static class StateNVList
    {
        public static List<KeyValuePair<Guid, String>> GetList()
        {
            return Fetch();
        }

        private static List<KeyValuePair<Guid, String>> Fetch()
        {
            IStateDal IstateDal = new StateDal();
            List<KeyValuePair<Guid, String>> stateList = new List<KeyValuePair<Guid, String>>();
            foreach (var item in IstateDal.Fetch())
            {
                stateList.Add(new KeyValuePair<Guid, string>(item.Id, item.Name));
            }
            return stateList;
        }

        public static List<KeyValuePair<Guid, String>> GetListByCountryId(Guid CountryId)
        {
            return FetchByCountryId(CountryId);
        }

        private static List<KeyValuePair<Guid, String>> FetchByCountryId(Guid CountryId)
        {
            IStateDal IstateDal = new StateDal();
            List<KeyValuePair<Guid, String>> stateList = new List<KeyValuePair<Guid, String>>();
            foreach (var item in IstateDal.FetchByCountryId(CountryId))
            {
                stateList.Add(new KeyValuePair<Guid, string>(item.Id, item.Name));
            }
            return stateList;
        }
    }
}
