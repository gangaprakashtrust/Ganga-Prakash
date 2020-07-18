using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class InternalChat : BaseModel
    {
        [Required]
        public Guid ApplicationUserId { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Text { get; set; }

        public DateTime DateTime { get; set; }

        public Boolean IsReceiver { get; set; }
    }
}
