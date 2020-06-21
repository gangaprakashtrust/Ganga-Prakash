using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class RoleMenuPrivilege : BaseModel
    {
        public Guid RoleMenuId { get; set; }

        public Guid PrivilegeId { get; set; }
    }
}
