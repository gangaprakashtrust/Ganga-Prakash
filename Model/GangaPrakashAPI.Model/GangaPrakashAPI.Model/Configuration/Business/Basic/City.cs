using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class City : BaseModel
    {
        public Guid CountryId { get; set; }

        [Required]
        public Guid StateId { get; set; }

        [Required]
        public String Name { get; set; }

        //Extra Fields

        public String Country { get; set; }

        public String State { get; set; }

        public List<KeyValuePair<Guid, String>> CountryNVList { get; set; }

        public List<KeyValuePair<Guid, String>> StateNVList { get; set; }
    }
}
