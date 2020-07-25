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
    public class CountryList
    {
        public static List<Country> GetList()
        {
            return Fetch();
        }

        private static List<Country> Fetch()
        {
            ICountryDal IcountryDal = new CountryDal();
            List<Country> countryList = new List<Country>();
            foreach (var item in IcountryDal.Fetch())
            {
                Country country = new Country
                {
                    Id = item.Id,
                    Name = item.Name
                };
                countryList.Add(country);
            }
            return countryList;
        }
    }
}
