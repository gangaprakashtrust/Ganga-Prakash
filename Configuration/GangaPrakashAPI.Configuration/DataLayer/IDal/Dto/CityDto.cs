using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Configuration.IDal
{
    public class CityDto
    {
        public Guid Id { get; set; }

        public Guid CountryId { get; set; }

        public Guid StateId { get; set; }

        public String Name { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

        // Extra Fields

        public String Country { get; set; }

        public String State { get; set; }

    }
}
