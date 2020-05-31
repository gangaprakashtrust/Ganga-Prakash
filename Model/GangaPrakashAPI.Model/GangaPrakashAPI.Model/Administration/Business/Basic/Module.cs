using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class Module:BaseModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$",ErrorMessage="Sequence Number must be numeric.")]
        [Display(Name = "Sequence Number")]
        public Int32 SequenceNo { get; set; }
    }
}
