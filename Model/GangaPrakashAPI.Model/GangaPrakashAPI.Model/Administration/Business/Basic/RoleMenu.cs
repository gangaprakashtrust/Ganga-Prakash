﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GangaPrakashAPI.Model
{
    public class RoleMenu : BaseModel
    {
        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }
    }
}
