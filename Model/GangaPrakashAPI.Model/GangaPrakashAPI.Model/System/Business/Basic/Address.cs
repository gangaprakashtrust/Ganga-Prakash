using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class Address : BaseModel
    {
        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public Guid StateId { get; set; }

        [Required]
        public Guid CityId { get; set; }

        [Required]
        public String AddressLine { get; set; }

        [Required]
        public String Area { get; set; }

        [Required]
        public String Pincode { get; set; }

        //Extra Fields

        public List<KeyValuePair<Guid, String>> CountryNVList { get; set; }

        public List<KeyValuePair<Guid, String>> StateNVList { get; set; }
    }
}
