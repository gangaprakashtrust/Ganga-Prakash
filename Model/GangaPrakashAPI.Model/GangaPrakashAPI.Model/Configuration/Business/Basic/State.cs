using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class State : BaseModel
    {
        public Guid CountryId { get; set; }

        [Required]
        public String Name { get; set; }

        //Extra Fields

        public String Country { get; set; }

        public List<KeyValuePair<Guid, String>> CountryNVList { get; set; }


    }
}
