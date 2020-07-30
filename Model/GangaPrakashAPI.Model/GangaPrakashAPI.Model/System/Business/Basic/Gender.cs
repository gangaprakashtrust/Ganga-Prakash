using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace GangaPrakashAPI.Model
{
    public class Gender : BaseModel
    {

        [Required]
        public String Name { get; set; }

    }
}
