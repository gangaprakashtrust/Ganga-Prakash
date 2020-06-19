using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class RoleTrans : BaseModel
    {
        public Role role { get; set; }

        public List<MenuHelper> menuList { get; set; }
    }
}
