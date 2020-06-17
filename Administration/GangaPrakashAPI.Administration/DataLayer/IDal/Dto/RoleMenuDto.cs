using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Administration.IDal
{
    public class RoleMenuDto
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 ErrorCount { get; set; }

        public String ErrorMessage { get; set; }
    }
}
