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
    public static class CountryNVList
    {
        public static List<KeyValuePair<Guid, String>> GetList()
        {
            return Fetch();
        }

        private static List<KeyValuePair<Guid, String>> Fetch()
        {
            ICountryDal IcountryDal = new CountryDal();
            List<KeyValuePair<Guid, String>> countryList = new List<KeyValuePair<Guid, String>>();
            foreach (var item in IcountryDal.Fetch())
            {
                countryList.Add(new KeyValuePair<Guid, string>(item.Id, item.Name));
            }
            return countryList;
        }
    }
}
