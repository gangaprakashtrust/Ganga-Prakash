using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class UserRole : BaseModel
    {
        public Guid ApplicationUserId { get; set; }

        public Guid RoleId { get; set; }

    }
}
