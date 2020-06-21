using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class RoleMenuPrivilegeHelper : BaseModel
    {
        public String Menu { get; set; }

        public String Module { get; set; }

        public String Name { get; set; }

        public Guid ModuleId { get; set; }

        public Guid MenuId { get; set; }

        public Guid PrivilegeId { get; set; }

        public Guid RoleMenuId { get; set; }

        public Int32 MenuSequenceNo { get; set; }

        public Int32 PrivilegeSequenceNo { get; set; }

    }
}
