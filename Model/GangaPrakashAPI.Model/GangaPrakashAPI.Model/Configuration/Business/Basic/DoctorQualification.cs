using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class DoctorQualification : BaseModel
    {
        public Guid DoctorId { get; set; }

        [Required]
        public String Qualification { get; set; }

        [Required]
        public String YearOfPassing { get; set; }

        [Required]
        public String Grade { get; set; }

    }
}
