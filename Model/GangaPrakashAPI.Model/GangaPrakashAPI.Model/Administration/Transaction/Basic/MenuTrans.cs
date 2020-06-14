using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class MenuTrans : BaseModel
    {
        public Menu menu { get; set; }

        public List<Privilege> privilegeList { get; set; }
    }
}
