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
    public class CountryPersister
    {
        public Country Insert(Country country, SqlConnection con = null, SqlTransaction trans = null)
        {
            ICountryDal IcountryDal = new CountryDal();
            CountryDto countryDto = new CountryDto
            {
                Name = country.Name,
                IsActive = true
            };
            IcountryDal.IsCountryAlreadyPresent(countryDto);
            if (countryDto.ErrorCount == 0)
            {
                IcountryDal.Insert(countryDto, con, trans);
                country.Id = countryDto.Id;

            }
            else
            {
                country.IsError = true;
                country.ErrorMessage = countryDto.ErrorMessage;
                country.ErrorMessageFor = "Name";

            }
            return country;
        }

        public Country Update(Country country, SqlConnection con = null, SqlTransaction trans = null)
        {
            ICountryDal IcountryDal = new CountryDal();
            CountryDto countryDto = new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                IsActive = true
            };
            IcountryDal.IsCountryAlreadyPresent(countryDto);
            if (countryDto.ErrorCount == 0)
            {
                IcountryDal.Update(countryDto, con, trans);
                country.Id = countryDto.Id;
            }
            else
            {
                country.IsError = true;
                country.ErrorMessage = countryDto.ErrorMessage;
                country.ErrorMessageFor = "Name";

            }
            return country;
        }

        public Country Delete(Country country, SqlConnection con = null, SqlTransaction trans = null)
        {
            ICountryDal IcountryDal = new CountryDal();
            CountryDto countryDto = new CountryDto
            {
                Id = country.Id,
                IsActive = false
            };
            Boolean IsStateReferencePresent = IcountryDal.IsStateReferencePresent(countryDto.Id);
            if (!IsStateReferencePresent)
            {
                IcountryDal.Delete(countryDto, con, trans);
                country.Id = countryDto.Id;
            }
            else
            {
                country.IsError = true;
                country.ErrorMessage = "Please first delete states under country " + country.Name;
                country.ErrorMessageFor = "Name";
            }
            return country;
        }

    public static Country GetCountry(Guid Id)
    {
        ICountryDal IcountryDal = new CountryDal();
        CountryDto countryDto = IcountryDal.FetchById(Id);
        Country country = new Country
        {
            Id = countryDto.Id,
            Name = countryDto.Name
        };
        return country;
    }

    public static Country Get()
    {
        Country country = new Country();
        return country;
    }

    public static CountryPersister GetPersister()
    {
        CountryPersister countryPersister = new CountryPersister();
        return countryPersister;
    }
}
}
