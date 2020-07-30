using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public class AddressDto
    {
        public Guid Id { get; set; }
       
        public Guid CountryId { get; set; }
       
        public Guid StateId { get; set; }
       
        public Guid CityId { get; set; }
       
        public String AddressLine { get; set; }
       
        public String Area { get; set; }
       
        public String Pincode { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

    }
}
