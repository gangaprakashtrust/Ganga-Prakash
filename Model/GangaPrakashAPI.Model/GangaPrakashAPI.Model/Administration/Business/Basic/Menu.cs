using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class Menu : BaseModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String Controller { get; set; }

        [Required]
        public String Action { get; set; }

        [Required]
        public String Area { get; set; }

        [Required]
        [RegularExpression("0*[1-9][0-9]*", ErrorMessage = "Sequence Number must be numeric.")]
        [Display(Name = "Sequence Number")]
        public Int32 SequenceNo { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        [Display(Name = "Module")]
        public Guid ModuleId { get; set; }

        //Extra Fields

        public String ParentMenu { get; set; }

        public String Module { get; set; }

        public List<KeyValuePair<Guid, String>> ModuleNVList { get; set; }

        public List<KeyValuePair<Guid, String>> MenuNVList { get; set; }

        public Boolean IsParent { get; set; }

    }
}
