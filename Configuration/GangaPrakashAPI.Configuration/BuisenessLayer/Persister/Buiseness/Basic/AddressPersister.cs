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
    public class AddressPersister
    {
        public Address Insert(Address address, SqlConnection con = null, SqlTransaction trans = null)
        {
            IAddressDal IaddressDal = new AddressDal();
            AddressDto addressDto = new AddressDto
            {
                CountryId = address.CountryId,
                StateId = address.StateId,
                CityId = address.CityId,
                AddressLine = address.AddressLine,
                Area = address.Area,
                Pincode = address.Pincode,
                IsActive = true
            };
            IaddressDal.Insert(addressDto, con, trans);
            address.Id = addressDto.Id;
            return address;
        }

        public Address Update(Address address, SqlConnection con = null, SqlTransaction trans = null)
        {
            IAddressDal IaddressDal = new AddressDal();
            AddressDto addressDto = new AddressDto
            {
                Id = address.Id,
                CountryId = address.CountryId,
                StateId = address.StateId,
                CityId = address.CityId,
                AddressLine = address.AddressLine,
                Area = address.Area,
                Pincode = address.Pincode,
                IsActive = true
            };
            IaddressDal.Update(addressDto, con, trans);
            address.Id = addressDto.Id;
            return address;
        }

        public Address Delete(Address address, SqlConnection con = null, SqlTransaction trans = null)
        {
            IAddressDal IaddressDal = new AddressDal();
            AddressDto addressDto = new AddressDto
            {
                Id = address.Id,
                IsActive = false
            };
            IaddressDal.Delete(addressDto, con, trans);
            address.Id = addressDto.Id;
            return address;
        }

        public static Address GetAddress(Guid Id)
        {
            IAddressDal IaddressDal = new AddressDal();
            AddressDto addressDto = IaddressDal.FetchById(Id);
            Address address = new Address
            {
                Id = addressDto.Id,
                CountryId = addressDto.CountryId,
                StateId = addressDto.StateId,
                CityId = addressDto.CityId,
                AddressLine = addressDto.AddressLine,
                Area = addressDto.Area,
                Pincode = addressDto.Pincode
            };
            return address;
        }

        public static Address Get()
        {
            Address address = new Address();
            return address;
        }

        public static AddressPersister GetPersister()
        {
            AddressPersister addressPersister = new AddressPersister();
            return addressPersister;
        }
    }
}
