using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public class RoleMenuPrivilegeHelperDto
    {
        public Guid Id { get; set; }

        public String Menu { get; set; }

        public String Module { get; set; }

        public String Name { get; set; }

        public Guid ModuleId { get; set; }

        public Guid MenuId { get; set; }

        public Guid PrivilegeId { get; set; }

        public Guid RoleMenuId { get; set; }

        public Int32 ModuleSequenceNo { get; set; }

        public Int32 MenuSequenceNo { get; set; }

        public Int32 PrivilegeSequenceNo { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }

        public Boolean IsChecked { get; set; }

    }
}
