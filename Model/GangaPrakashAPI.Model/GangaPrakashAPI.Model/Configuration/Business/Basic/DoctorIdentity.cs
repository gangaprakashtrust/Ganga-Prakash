using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class DoctorIdentity : BaseModel
    {
        public Guid DoctorId { get; set; }

        [Required]
        public Guid IdentityTypeId { get; set; }

        [Required]
        public String IdentityNo { get; set; }

    }
}
