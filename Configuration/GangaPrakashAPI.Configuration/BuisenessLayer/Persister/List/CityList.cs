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
    public class CityList
    {
        public static List<City> GetList()
        {
            return Fetch();
        }

        private static List<City> Fetch()
        {
            ICityDal IcityDal = new CityDal();
            List<City> cityList = new List<City>();
            foreach (var item in IcityDal.Fetch())
            {
                City city = new City
                {
                    Id = item.Id,
                    CountryId=item.CountryId,
                    StateId = item.StateId,
                    Name = item.Name,
                    Country = item.Country,
                    State = item.State
                };
                cityList.Add(city);
            }
            return cityList;
        }
    }
}
