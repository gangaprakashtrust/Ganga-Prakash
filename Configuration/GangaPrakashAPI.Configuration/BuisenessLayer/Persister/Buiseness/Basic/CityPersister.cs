using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Configuration.Dal;
using GangaPrakashAPI.Configuration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Configuration.Persister
{
    public class CityPersister
    {
        public City Insert(City city, SqlConnection con = null, SqlTransaction trans = null)
        {
            ICityDal IcityDal = new CityDal();
            CityDto cityDto = new CityDto
            {
                CountryId = city.CountryId,
                StateId = city.StateId,
                Name = city.Name,
                IsActive = true
            };
            IcityDal.IsCityAlreadyPresent(cityDto);
            if (cityDto.ErrorCount == 0)
            {
                IcityDal.Insert(cityDto, con, trans);
                city.Id = cityDto.Id;

            }
            else
            {
                city.IsError = true;
                city.ErrorMessage = cityDto.ErrorMessage;
                city.ErrorMessageFor = "Name";

            }
            return city;
        }

        public City Update(City city, SqlConnection con = null, SqlTransaction trans = null)
        {
            ICityDal IcityDal = new CityDal();
            CityDto cityDto = new CityDto
            {
                Id = city.Id,
                CountryId = city.CountryId,
                StateId = city.StateId,
                Name = city.Name,
                IsActive = true
            };
            IcityDal.IsCityAlreadyPresent(cityDto);
            if (cityDto.ErrorCount == 0)
            {
                IcityDal.Update(cityDto, con, trans);
                city.Id = cityDto.Id;
            }
            else
            {
                city.IsError = true;
                city.ErrorMessage = cityDto.ErrorMessage;
                city.ErrorMessageFor = "Name";

            }
            return city;
        }

        public City Delete(City city, SqlConnection con = null, SqlTransaction trans = null)
        {
            ICityDal IcityDal = new CityDal();
            CityDto cityDto = new CityDto
            {
                Id = city.Id,
                IsActive = false
            };
            IcityDal.Delete(cityDto, con, trans);
            city.Id = cityDto.Id;
            return city;
        }

        public static City GetCity(Guid Id)
        {
            ICityDal IcityDal = new CityDal();
            CityDto cityDto = IcityDal.FetchById(Id);
            City city = new City
            {
                Id = cityDto.Id,
                CountryId = cityDto.CountryId,
                StateId = cityDto.StateId,
                Name = cityDto.Name,
                Country = cityDto.Country,
                State = cityDto.State
            };
            return city;
        }

        public static City Get()
        {
            City city = new City();
            return city;
        }

        public static CityPersister GetPersister()
        {
            CityPersister cityPersister = new CityPersister();
            return cityPersister;
        }
    }
}
