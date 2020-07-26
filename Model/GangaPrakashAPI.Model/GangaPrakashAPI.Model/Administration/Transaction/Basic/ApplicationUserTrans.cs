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
    public class ApplicationUserTrans : BaseModel
    {
        public ApplicationUser applicationUser { get; set; }

        public List<Role> roleList { get; set; }

        public String ConfirmEmailToken { get; set; }

    }
}
